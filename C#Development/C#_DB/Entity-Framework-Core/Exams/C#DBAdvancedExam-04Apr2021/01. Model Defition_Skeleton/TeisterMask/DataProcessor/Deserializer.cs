namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb  = new StringBuilder();
            var projects = XmlConverter.Deserializer<ProjectXmlInputModel>(xmlString, "Projects");

            foreach ( var currProject in projects )
            {
                if (!IsValid(currProject))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidOpenDate = DateTime.TryParseExact(currProject.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime openDate);

                if (!isValidOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;
                if (!String.IsNullOrWhiteSpace(currProject.DueDate))
                {
                    var isValidDueDate = DateTime.TryParseExact(currProject.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime dueDateValue);

                    if (!isValidDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateValue;
                }

                    var project = new Project
                    {
                        Name = currProject.Name,
                        OpenDate = openDate,
                        DueDate = dueDate,
                    };

                foreach (var task in currProject.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isOpenDateValid = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime outDate);

                    if (!isOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isDueDateValid = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDateValue);

                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (outDate < openDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDate.HasValue && dueDateValue > dueDate.Value)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newTask = new Task
                    {
                        Name = task.Name,
                        OpenDate = openDate,
                        DueDate = dueDateValue,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType
                    };

                    project.Tasks.Add(newTask);
                }

                context.Projects.Add(project);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count()));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeJsonInputModel>>(jsonString);
            var sb = new StringBuilder();

            foreach (var item in employees)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = item.Username,
                    Email = item.Email,
                    Phone = item.Phone
                };

                var uniqueTasks = item.Tasks.Distinct();

                foreach (var task in uniqueTasks)
                {
                    var currentTask = context.Tasks.FirstOrDefault(t => t.Id == task);

                    if (currentTask == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        TaskId = task
                    });
                }

                context.Employees.Add(employee);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count()));
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