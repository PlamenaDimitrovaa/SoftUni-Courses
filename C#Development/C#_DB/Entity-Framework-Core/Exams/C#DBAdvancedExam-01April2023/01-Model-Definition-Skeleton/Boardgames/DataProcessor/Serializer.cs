namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .Select(c => new ExportXmlCreatorDto
                {
                    CreatorName = c.FirstName + " " + c.LastName,
                    BoardgamesCount = c.Boardgames.Count(),
                    Boardgames = c.Boardgames
                                .Select(b => new ExportXmlBoardgameDto()
                                {
                                    BoardgameName = b.Name,
                                    BoardgameYearPublished = b.YearPublished,
                                })
                                .OrderBy(b => b.BoardgameName)
                                .ToArray()  
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorName)
                .ToArray();

            return xmlHelper.Serialize(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any() && s.BoardgamesSellers.Any(bs =>
                bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .ToArray()
                .Select(s => new ExportJsonSellerDto()
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                                .Where(bs => bs.Boardgame.YearPublished >= year
                                && bs.Boardgame.Rating <= rating)
                                .Select(bs => new ExportJsonBoardgameDto()
                                {
                                    Name = bs.Boardgame.Name,
                                    Rating = bs.Boardgame.Rating,
                                    Mechanics = bs.Boardgame.Mechanics,
                                    Category = bs.Boardgame.CategoryType.ToString()
                                })
                                .OrderByDescending(s => s.Rating)
                                .ThenBy(s => s.Name)
                                .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Count())
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}