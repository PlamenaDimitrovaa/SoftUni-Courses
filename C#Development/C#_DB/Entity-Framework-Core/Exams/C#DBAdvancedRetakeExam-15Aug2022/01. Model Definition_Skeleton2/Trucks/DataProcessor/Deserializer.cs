namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
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

        private static XmlHelper xmlHelper;

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            xmlHelper = new XmlHelper();
            var despatcherDtos = xmlHelper.Deserialize<ImportXmlDespatcherDto[]>(xmlString, "Despatchers");
            var sb = new StringBuilder();

            ICollection<Despatcher> despatchers = new HashSet<Despatcher>();

            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Truck> validTrucks = new HashSet<Truck>();  

                //var despatcher = new Despatcher()
                //{
                //    Name = despatcherDto.Name,
                //    Position = despatcherDto.Position
                //};

                foreach (var currTruck in despatcherDto.Trucks)
                {
                    //if (currTruck == null)
                    //{
                    //    sb.AppendLine(ErrorMessage);
                    //    continue;
                    //}

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

                    validTrucks.Add(truck);
                }

                Despatcher despatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                    Trucks = validTrucks
                };

                despatchers.Add(despatcher);
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, despatcher.Name, validTrucks.Count));        
            }

            context.Despatchers.AddRange(despatchers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var sb = new StringBuilder();
            ImportJsonClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportJsonClientDto[]>(jsonString);

            ICollection<Client> validClients = new HashSet<Client>();
            ICollection<int> existingTruckIds = context.Trucks
                .Select(t => t.Id)
                .ToArray();

            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };

                foreach (var truckId in clientDto.TruckIds.Distinct())
                {
                    if (!existingTruckIds.Contains(truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ClientTruck clientTruck = new ClientTruck()
                    {
                        Client = client,
                        TruckId = truckId
                    };

                    client.ClientsTrucks.Add(clientTruck);
                }

                validClients.Add(client);
                sb.AppendLine(String.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.Clients.AddRange(validClients);
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