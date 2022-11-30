namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Microsoft.VisualBasic;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(x => x.Tasks.Any())
                .ToArray()
                .Select(x => new ProjectXmlOutputModel
                {
                    ProjectName = x.Name,
                    TasksCount = x.Tasks.Count(),
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(t => new TaskXmlOutputModel
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString(),
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            var result = XmlConverter.Serialize(projects, "Projects");
            return result;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToArray()
                .Where(x => x.EmployeesTasks.Any(e => e.Task.OpenDate >= date))
                .Select(x => new
                {
                    x.Username,
                    Tasks = x.EmployeesTasks
                        .Where(e => e.Task.OpenDate >= date)
                        .Select(e => e.Task)
                        .OrderByDescending(x => x.DueDate)
                        .ThenBy(x => x.Name)
                        .Select(x => new
                            {
                                TaskName = x.Name,
                                OpenDate = x.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                DueDate = x.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                LabelType = x.LabelType.ToString(),
                                ExecutionType = x.ExecutionType.ToString(),
                        })
                        .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            string result = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return result;
        }
    }
}