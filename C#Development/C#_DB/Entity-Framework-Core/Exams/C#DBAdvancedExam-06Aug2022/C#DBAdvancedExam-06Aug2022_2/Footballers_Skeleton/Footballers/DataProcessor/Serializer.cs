namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Footballers.Utilities;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches
                .ToArray()
                .Where(c => c.Footballers.Any())
                .Select(c => new ExportXmlCoachDto
                {
                    CoachName = c.Name,
                    FootballersCount = c.Footballers.Count,
                    Footballers = c.Footballers
                                    .ToArray()
                                    .Select(f => new ExportXmlFootballerDto
                                    {
                                        Name = f.Name,
                                        Position = f.PositionType.ToString(),
                                    })
                                    .OrderBy(f => f.Name)
                                    .ToArray()
                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.CoachName)
                .ToArray();


            var xmlSerializer = new XmlSerializer(typeof(ExportXmlCoachDto[]), new XmlRootAttribute("Coaches"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);
            var sw = new StringWriter();

            xmlSerializer.Serialize(sw, coaches, namespaces);

            return sw.ToString();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                            .ToList()
                            .Where(t => t.TeamsFootballers.Any(x => x.Footballer.ContractStartDate >= date))
                            .Select(t => new ExportJsonTeamDto
                            {
                                Name = t.Name,
                                Footballers = t.TeamsFootballers
                                                .ToList()
                                                .Select(x => x.Footballer)
                                                .Where(f => f.ContractStartDate >= date)
                                                .OrderByDescending(f => f.ContractEndDate)
                                                .ThenBy(f => f.Name)
                                                .Select(f => new ExportJsonFootballerDto
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
