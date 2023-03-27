namespace Footballers.DataProcessor
{
    using AutoMapper;
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Footballers.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportXmlCoachDto[]), 
                new XmlRootAttribute("Coaches"));
            var sr = new StringReader(xmlString);
            var coaches = (ImportXmlCoachDto[])xmlSerializer.Deserialize(sr);
            var sb = new StringBuilder();

            foreach (var item in coaches)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var coach = new Coach()
                {
                    Name = item.Name,
                    Nationality = item.Nationality
                };

                foreach (var footballer in item.Footballers)
                {
                    if (!IsValid(footballer))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var isContractStartDateParsed =
                        DateTime.TryParseExact(footballer.ContractStartDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out var startDate);

                    var isContractEndDateParsed =
                        DateTime.TryParseExact(footballer.ContractEndDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out var endDate);

                    if (!isContractStartDateParsed || !isContractEndDateParsed)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    if (startDate > endDate)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    coach.Footballers.Add(new Footballer
                    {
                        Name = footballer.Name,
                        PositionType = (PositionType)footballer.PositionType,
                        BestSkillType = (BestSkillType)footballer.BestSkillType,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate
                    });
                }

                context.Coaches.Add(coach);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported coach - {coach.Name} with {coach.Footballers.Count} footballers.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            IMapper mapper = InitializeAutoMapper();
            var sb = new StringBuilder();
            var dtoTeams = JsonConvert.DeserializeObject<IEnumerable<ImportJsonTeamDto>>(jsonString);

            foreach (var teamDto in dtoTeams)
            {
                if (!IsValid(teamDto) || teamDto.Trophies <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies
                };


                foreach (var footballerId in teamDto.Footballers.Distinct())
                {
                    var footballer = context.Footballers.FirstOrDefault(f => f.Id == footballerId);

                    if (footballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer
                    {
                        FootballerId = footballerId
                    });
                }

                context.Teams.Add(team);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported team - {team.Name} with {team.TeamsFootballers.Count} footballers.");
            }

           return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static IMapper InitializeAutoMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            }));
        }
    }
}
