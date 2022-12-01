namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var plays = XmlConverter.Deserializer<PlayXmlInputModel>(xmlString, "Plays");
            var sb = new StringBuilder();

            foreach (var currPlay in plays)
            {
                if (!IsValid(currPlay))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isDurationParsed = TimeSpan.TryParseExact(
                    currPlay.Duration.ToString(),
                    "c",
                    CultureInfo.InvariantCulture,
                    out TimeSpan result);

                if (!isDurationParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (result.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play
                {
                    Title = currPlay.Title,
                    Duration = result,
                    Rating = currPlay.Rating,
                    Genre = Enum.Parse<Genre>(currPlay.Genre),
                    Description = currPlay.Description,
                    Screenwriter = currPlay.Screenwriter
                };

                context.Plays.Add(play);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var casts = XmlConverter.Deserializer<CastXmlInputModel>(xmlString, "Casts");

            foreach (var currCast in casts)
            {
                if (!IsValid(currCast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast
                {
                    FullName = currCast.FullName,
                    IsMainCharacter = currCast.IsMainCharacter,
                    PhoneNumber = currCast.PhoneNumber,
                    PlayId = currCast.PlayId
                };

                context.Casts.Add(cast);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var theatersTickets = JsonConvert.DeserializeObject<IEnumerable<TheatreJsonInputModel>>(jsonString);

            foreach (var item in theatersTickets)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre
                {
                    Name = item.Name,
                    NumberOfHalls = item.NumberOfHalls,
                    Director = item.Director,                
                };

                foreach (var currTicket in item.Tickets)
                {
                    if (!IsValid(currTicket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket
                    {

                        Price = currTicket.Price,
                        RowNumber = currTicket.RowNumber,
                        PlayId = currTicket.PlayId
                    };

                    theatre.Tickets.Add(ticket);
                }

                context.Theatres.Add(theatre);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
