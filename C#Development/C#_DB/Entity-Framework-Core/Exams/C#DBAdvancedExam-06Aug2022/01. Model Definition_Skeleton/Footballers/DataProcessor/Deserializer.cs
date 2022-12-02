namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var coaches = XmlConverter.Deserializer<CoachXmlInputModel>(xmlString, "Coaches");

            foreach (var currCoach in coaches)
            {
                if (!IsValid(currCoach))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach()
                {
                    Name = currCoach.Name,
                    Nationality = currCoach.Nationality,
                };

                foreach (var currFootballer in currCoach.Footballers)
                {
                    if (!IsValid(currFootballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isValidStartDate = DateTime
                        .TryParseExact(currFootballer.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate);
                    var isValidEndDate = DateTime
                        .TryParseExact(currFootballer.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDate);

                    if (!isValidEndDate || !isValidStartDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (startDate > endDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    coach.Footballers.Add(new Footballer
                    {
                        Name = currFootballer.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        BestSkillType = (BestSkillType)currFootballer.BestSkillType,
                        PositionType = (PositionType)currFootballer.PositionType,
                    });

                }
                    context.Coaches.Add(coach);
                    context.SaveChanges();
                    sb.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));

            }
                return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var teams = JsonConvert.DeserializeObject<TeamJsonInputModel[]>(jsonString);

            foreach (var currTeam in teams) 
            {
                if (!IsValid(currTeam) || currTeam.Trophies <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team()
                {
                    Name = currTeam.Name,
                    Nationality = currTeam.Nationality,
                    Trophies = currTeam.Trophies,
                };

                foreach (var currFootballer in currTeam.Footballers.Distinct())
                {
                    var footballer = context.Footballers.FirstOrDefault(f => f.Id == currFootballer);

                    if (footballer == null)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var footballerToAdd = new TeamFootballer
                    {
                        FootballerId = currFootballer
                    };

                    team.TeamsFootballers.Add(footballerToAdd);
                }

                context.Teams.Add(team);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

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
