
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .ToList()
                .Where(x => x.ShellWeight > shellWeight)
                .Select(x => new 
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns
                        .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                        .Select(g => new 
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        })
                        .OrderByDescending(g => g.GunWeight)
                        .ToList()
                })
                .OrderBy(x => x.ShellWeight)
                .ToList();

            var result = JsonConvert.SerializeObject(shells, Formatting.Indented);
            return result;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .Select(x => new GunOutputModel
                {
                    Manufactrurer = x.Manufacturer.ManufacturerName,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight,
                    BarrelLength = x.BarrelLength,
                    Range = x.Range,
                    Countries = x.CountriesGuns
                        .Where(c => c.Country.ArmySize > 4500000)
                        .Select(c => new CountryOutputModel
                        {
                            Country = c.Country.CountryName,
                            ArmySize = c.Country.ArmySize,
                        })
                        .OrderBy(c => c.ArmySize)
                        .ToArray()
                })
                .OrderBy(x => x.BarrelLength)
                .ToList();

            var result = XmlConverter.Serialize(guns, "Guns");
            return result;

        }
    }
}
