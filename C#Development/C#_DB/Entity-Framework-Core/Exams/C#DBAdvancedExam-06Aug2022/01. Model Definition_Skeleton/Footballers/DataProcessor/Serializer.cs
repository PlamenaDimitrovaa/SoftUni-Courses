namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .ToList()
                .Where(t => t.TeamsFootballers.Any(x => x.Footballer.ContractStartDate >= date))
                .Select(t => new TeamJsonOutputModel
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                                    .ToList()
                                    .Select(x => x.Footballer)
                                    .Where(f => f.ContractStartDate >= date)
                                    .OrderByDescending(f => f.ContractEndDate)
                                    .ThenBy(f => f.Name)
                                    .Select(f => new FootballerJsonOutputModel
                                    {
                                        FootballerName = f.Name,
                                        ContractStartDate = f.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                                        ContractEndDate = f.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                                        BestSkillType = f.BestSkillType.ToString(),
                                        PositionType = f.PositionType.ToString()
                                    })
                                    .ToList()
                })
                .OrderByDescending(t => t.Footballers.Count)
                .ThenBy(t => t.Name)
                .Take(5)
                .ToList();

            var result = JsonConvert.SerializeObject(teams, Formatting.Indented);

            return result;
        }

    }
}
