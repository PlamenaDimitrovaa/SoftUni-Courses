namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Artillery.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            var countriesDtos = xmlHelper.Deserialize<ImportXmlCountryDto[]>(xmlString, "Countries");
            var sb = new StringBuilder();

            ICollection<Country> countries = new HashSet<Country>();

            foreach (var countryDto in countriesDtos)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize
                };

                countries.Add(country);
                sb.AppendLine(String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var sb = new StringBuilder();

            var manufacturerDtos = xmlHelper
                .Deserialize<ImportXmlManufacturerDto[]>(xmlString, "Manufacturers");

            foreach (var manufacturerDto in manufacturerDtos)
            {
                if (!IsValid(manufacturerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufact = context.Manufacturers
                    .FirstOrDefault(m => m.ManufacturerName == manufacturerDto.ManufacturerName);

                if (manufact != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer()
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                };

                var splitted = manufacturerDto.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                splitted.RemoveRange(0, splitted.Count - 2);

                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, String.Join(", ", splitted)));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            var sb = new StringBuilder();
            var shellsDtos = xmlHelper
                .Deserialize<ImportXmlShellDto[]>(xmlString, "Shells");

            foreach (var shellDto in shellsDtos)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber,
                };
               
                context.Shells.Add(shell);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var guns = JsonConvert.DeserializeObject<IEnumerable<ImportJsonGunDto>>(jsonString);

            foreach (var currGun in guns)
            {
                if (!IsValid(currGun))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun()
                {
                    ManufacturerId = currGun.ManufacturerId,
                    GunWeight = currGun.GunWeight,
                    BarrelLength = currGun.BarrelLength,
                    NumberBuild = currGun.NumberBuild,
                    Range = currGun.Range,
                    GunType = Enum.Parse<GunType>(currGun.GunType),
                    ShellId = currGun.ShellId,
                };

                foreach (var country in currGun.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun()
                    {
                        CountryId = country.Id,
                    });
                }

                context.Guns.Add(gun);
                context.SaveChanges();

                sb.AppendLine(String.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
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