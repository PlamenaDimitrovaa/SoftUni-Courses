namespace Trucks.DataProcessor
{
    using System;
    using System.Linq;
    using AutoMapper;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchers = context.Despatchers
                .Where(x => x.Trucks.Any())
                .ToArray()
                .Select(x => new DespatcherExportModel()
                {
                    TrucksCount = x.Trucks.Count(),
                    DespatcherName = x.Name,
                    Trucks = x.Trucks.Select(t => new TruckExportModel()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString(),
                    })
                    .OrderBy(x => x.RegistrationNumber)
                    .ToArray()
                })
                .OrderByDescending(x => x.TrucksCount)
                .ThenBy(x => x.DespatcherName)
                .ToArray();

            var result = XmlConverter.Serialize(despatchers, "Despatchers");
            return result;
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {       
            var clients = context.Clients
               .Where(x => x.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
               .ToArray()
               .Select(x => new
               {
                   x.Name,
                   Trucks = x.ClientsTrucks
                       .Where(ct => ct.Truck.TankCapacity >= capacity)
                       .ToArray()
                       .OrderBy(ct => ct.Truck.MakeType.ToString())
                       .ThenByDescending(ct => ct.Truck.CargoCapacity)
                       .Select(ct => new
                       {
                           TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                           VinNumber = ct.Truck.VinNumber,
                           TankCapacity = ct.Truck.TankCapacity,
                           CargoCapacity = ct.Truck.CargoCapacity,
                           CategoryType = ct.Truck.CategoryType.ToString(),
                           MakeType= ct.Truck.MakeType.ToString(),
                       })
                       .ToArray()
               })
               .OrderByDescending(x => x.Trucks.Length)
               .ThenBy(x => x.Name)
               .Take(10)
               .ToArray();

            var result = JsonConvert.SerializeObject(clients, Formatting.Indented);

            return result;
        }

    }
}
