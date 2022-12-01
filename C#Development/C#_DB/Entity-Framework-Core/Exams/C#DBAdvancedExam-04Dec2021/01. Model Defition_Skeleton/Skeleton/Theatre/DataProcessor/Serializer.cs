namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Linq;
    using Theatre.Data;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context.Theatres
                .ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count() >= 20)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Sum(x => x.Price),
                    Tickets = x.Tickets.ToArray().Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                    .Select(x => new
                    {
                        Price = x.Price,
                        RowNumber = x.RowNumber
                    })
                    .OrderByDescending(x => x.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToArray();

            var result = JsonConvert.SerializeObject(theaters, Formatting.Indented);
            return result;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .ToArray()
                .Where(x => x.Rating <= rating)
                .Select(x => new PlayXmlOutputModel
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                        .ToArray()
                        .Where(a => a.IsMainCharacter == true)
                        .Select(a => new ActorXmlOutputModel
                        {
                            FullName = a.FullName,
                            MainCharacter = $"Plays main character in '{x.Title}'.",
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToArray();

            var result = XmlConverter.Serialize(plays, "Plays");
            return result;
        }
    }
}
