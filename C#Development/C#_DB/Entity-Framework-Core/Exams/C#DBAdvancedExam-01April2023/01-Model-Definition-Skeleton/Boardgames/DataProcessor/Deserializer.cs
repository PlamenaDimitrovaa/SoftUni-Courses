namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Boardgames.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            var sb = new StringBuilder();

            var creatorDtos = xmlHelper
                .Deserialize<ImportXmlCreatorDto[]>(xmlString, "Creators");

            ICollection<Creator> creators = new HashSet<Creator>();

            foreach (var creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Boardgame> validBoardgames = new HashSet<Boardgame>();

                foreach (var currBoardgame in creatorDto.Boardgames)
                {
                    if (!IsValid(currBoardgame) || String.IsNullOrEmpty(currBoardgame.Name))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgame = new Boardgame()
                    {
                        Name = currBoardgame.Name,
                        Rating = currBoardgame.Rating,
                        YearPublished = currBoardgame.YearPublished,
                        CategoryType = (CategoryType)currBoardgame.CategoryType,
                        Mechanics = currBoardgame.Mechanics
                    };

                    validBoardgames.Add(boardgame);
                }

                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                    Boardgames = validBoardgames
                };

                creators.Add(creator);
                sb.AppendLine(String.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }

            context.Creators.AddRange(creators);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sb = new StringBuilder();
            ImportJsonSellerDto[] sellerDtos = JsonConvert.
                DeserializeObject<ImportJsonSellerDto[]>(jsonString);

            ICollection<Seller> validSellers = new HashSet<Seller>();
            ICollection<int> existingBoardgameIds = context.Boardgames
                .Select(b => b.Id)
                .ToArray();

            foreach (var sellerDto in sellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website,
                };

                foreach (var boardgameId in sellerDto.Boardgames.Distinct())
                {
                    if (!existingBoardgameIds.Contains(boardgameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        BoardgameId = boardgameId,
                        SellerId = seller.Id
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }

                validSellers.Add(seller);
                sb.AppendLine(String.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }

            context.Sellers.AddRange(validSellers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
