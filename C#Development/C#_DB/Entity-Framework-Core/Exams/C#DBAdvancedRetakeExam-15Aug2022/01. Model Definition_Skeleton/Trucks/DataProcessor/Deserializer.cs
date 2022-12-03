namespace Trucks.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var despatchers = XmlConverter.Deserializer<ImportDespatcherModel>(xmlString, "Despatchers");

            foreach (var currDespatcher in despatchers)
            {
                if (!IsValid(currDespatcher))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var despatcher = new Despatcher()
                {
                    Name = currDespatcher.Name,
                    Position = currDespatcher.Position,
                };

                foreach (var currTruck in currDespatcher.Trucks)
                {
                    if(currTruck == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }   

                    if (!IsValid(currTruck))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var truck = new Truck()
                    {
                        RegistrationNumber = currTruck.RegistrationNumber,
                        VinNumber = currTruck.VinNumber,
                        TankCapacity = currTruck.TankCapacity,
                        CargoCapacity = currTruck.CargoCapacity,
                        CategoryType = (CategoryType)currTruck.CategoryType,
                        MakeType = (MakeType)currTruck.MakeType
                    };

                    despatcher.Trucks.Add(truck);
                }

                context.Despatchers.Add(despatcher);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var clients = JsonConvert.DeserializeObject<IEnumerable<ImportClientModel>>(jsonString);

            foreach (var currClient in clients)
            {
                if (!IsValid(currClient))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var client = new Client()
                {
                    Name = currClient.Name,
                    Nationality = currClient.Nationality,
                    Type = currClient.Type,
                };

                if (currClient.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var currTruck in currClient.Trucks.Distinct())
                {
                    Truck truck = context.Trucks.Find(currTruck);

                    if (truck == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    client.ClientsTrucks.Add(new ClientTruck()
                    {
                        TruckId = truck.Id,
                    });
                }

                context.Clients.Add(client);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
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
