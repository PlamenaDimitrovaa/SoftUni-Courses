namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var departments = new List<Department>();

            var departmentsCells = JsonConvert.DeserializeObject<IEnumerable<DepartmentCellInputModel>>(jsonString);

            foreach (var departmentCell in departmentsCells)
            {
                if (!IsValid(departmentCell) || !departmentCell.Cells.All(IsValid) || !departmentCell.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentCell.Name,
                    Cells = departmentCell.Cells.Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    })
                    .ToList()
                };

                departments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var prisoners = new List<Prisoner>();
            var prisonerMails = JsonConvert.DeserializeObject<IEnumerable<PrisonerMailInputModel>>(jsonString);
            foreach (var currPrisoner in prisonerMails)
            {
                if (!IsValid(currPrisoner) || !currPrisoner.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidReleaseDate = DateTime
                    .TryParseExact(currPrisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime releaseDate);
                var incarcerationDate = DateTime.ParseExact(currPrisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var prisoner = new Prisoner
                {
                    FullName = currPrisoner.FullName,
                    Nickname = currPrisoner.Nickname,
                    Age = currPrisoner.Age,
                    Bail = currPrisoner.Bail,
                    CellId = currPrisoner.CellId,
                    ReleaseDate = isValidReleaseDate ? (DateTime?)releaseDate : null,
                    IncarcerationDate = incarcerationDate,
                    Mails = currPrisoner.Mails.Select(m => new Mail
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address
                    })
                    .ToList()
                };

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}