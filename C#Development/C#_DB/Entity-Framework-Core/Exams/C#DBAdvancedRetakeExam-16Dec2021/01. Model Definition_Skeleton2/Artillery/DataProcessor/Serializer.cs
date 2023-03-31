
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Artillery.Utilities;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .ToArray()
                .Where(x => x.ShellWeight > shellWeight)
                .Select(x => new
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns
                            .ToArray()
                            .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                            .Select(g => new
                            {
                                GunType = g.GunType.ToString(),
                                GunWeight = g.GunWeight,
                                BarrelLength = g.BarrelLength,
                                Range = g.Range > 3000 ? "Long-range" : "Regular Range"
                            })
                            .OrderByDescending(g => g.GunWeight)
                            .ToArray()
                })
                .OrderBy(x => x.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new ExportXmlGunDto
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                                    .Where(cg => cg.Country.ArmySize > 4500000)
                                    .Select(cg => new ExportXmlCountryDto
                                    {
                                        Country = cg.Country.CountryName,
                                        ArmySize = cg.Country.ArmySize
                                    })
                                    .OrderBy(cg => cg.ArmySize)
                                    .ToArray()
                })
                .OrderBy(g => g.BarrelLength)
                .ToArray();

            XmlHelper xmlHelper = new XmlHelper();
            return xmlHelper.Serialize(guns, "Guns");
        }
    }
}
