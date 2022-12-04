namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;

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
            var sb = new StringBuilder();
            var countries = XmlConverter.Deserializer<CountryInputModel>(xmlString, "Countries");

            foreach (var currCountry in countries)
            {
                if (!IsValid(currCountry))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country()
                {
                    CountryName = currCountry.CountryName,
                    ArmySize = currCountry.ArmySize
                };

                context.Countries.Add(country);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var manufacturers = XmlConverter.Deserializer<ManufacturerInputModel>(xmlString, "Manufacturers");

            foreach (var currMan in manufacturers)
            {
                if (!IsValid(currMan))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufact = context.Manufacturers.FirstOrDefault(m => m.ManufacturerName == currMan.ManufacturerName);

                if (manufact != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer()
                {
                    ManufacturerName = currMan.ManufacturerName,
                    Founded = currMan.Founded
                };

                var splitted = currMan.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                splitted.RemoveRange(0, splitted.Count - 2);

                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, String.Join(", ", splitted)));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var shells = XmlConverter.Deserializer<ShellInputModel>(xmlString, "Shells");

            foreach (var currShell in shells)
            {
                if (!IsValid(currShell))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell()
                {
                    ShellWeight = currShell.ShellWeight,
                    Caliber = currShell.Caliber
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
            var guns = JsonConvert.DeserializeObject<IEnumerable<GunInputModel>>(jsonString);

            foreach (var currGun in guns)
            {
                if (!IsValid(currGun))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun
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
                    gun.CountriesGuns.Add(new CountryGun
                    {
                        CountryId = country.Id
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
