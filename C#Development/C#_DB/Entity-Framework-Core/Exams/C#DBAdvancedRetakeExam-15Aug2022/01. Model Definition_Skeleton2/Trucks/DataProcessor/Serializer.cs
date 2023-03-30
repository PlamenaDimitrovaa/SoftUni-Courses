namespace Trucks.DataProcessor
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Trucks.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var despatchers = context.Despatchers
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportXmlDespatcherDto()
                {
                    DespatcherName = d.Name,
                    TrucksCount = d.Trucks.Count,
                    Trucks = d.Trucks
                                .Select(t => new ExportXmlTruckDto()
                                {
                                    RegistrationNumber = t.RegistrationNumber,
                                    Make = t.MakeType.ToString()
                                })
                                .OrderBy(t => t.RegistrationNumber)
                                .ToArray()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            return xmlHelper.Serialize(despatchers, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Include(c => c.ClientsTrucks)
                .ThenInclude(ct => ct.Truck)
                .AsNoTracking()
                .ToArray()
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                             .Where(ct => ct.Truck.TankCapacity >= capacity)
                             .Select(ct => new
                             {
                                 TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                                 VinNumber = ct.Truck.VinNumber,
                                 TankCapacity = ct.Truck.TankCapacity,
                                 CargoCapacity = ct.Truck.CargoCapacity,
                                 CategoryType = ct.Truck.CategoryType.ToString(),
                                 MakeType = ct.Truck.MakeType.ToString()
                             })
                             .OrderBy(ct => ct.MakeType)
                             .ThenByDescending(ct => ct.CargoCapacity)
                             .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
