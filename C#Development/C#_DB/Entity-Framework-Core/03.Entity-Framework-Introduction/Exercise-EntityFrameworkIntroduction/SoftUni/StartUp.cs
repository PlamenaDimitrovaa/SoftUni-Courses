using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            Console.WriteLine("Connection Success");

            //string result = GetEmployeesFullInformation(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployeesWithSalaryOver50000(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployeesFromResearchAndDevelopment(dbContext);
            //Console.WriteLine(result);

            //string result = AddNewAddressToEmployee(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployeesInPeriod(dbContext);
            //Console.WriteLine(result);

            //string result = GetAddressesByTown(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployee147(dbContext);
            //Console.WriteLine(result);

            //string result = GetDepartmentsWithMoreThan5Employees(dbContext);
            //Console.WriteLine(result);

            //string result = GetLatestProjects(dbContext);
            //Console.WriteLine(result);

            //string result = IncreaseSalaries(dbContext);
            //Console.WriteLine(result);

            //string result = GetEmployeesByFirstNameStartingWithSa(dbContext);
            //Console.WriteLine(result);

            //string result = DeleteProjectById(dbContext);
            //Console.WriteLine(result);

            string result = RemoveTown(dbContext);
            Console.WriteLine(result);
        }

        //3.	Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //4. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary,
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //06. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee? employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = newAddress;

            context.SaveChanges();

            string[] employeeAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address!.AddressText)
                .ToArray();

            return String.Join(Environment.NewLine, employeeAddresses);
        }

        //07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employeesWithProjects = context.Employees
                //.Where(e => e.EmployeesProjects
                //    .Any(ep => ep.Project.StartDate.Year >= 2001
                //            && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager!.LastName,
                    Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                 ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) 
                            : "not finished"
                    })
                    .ToArray()
                })
                .ToArray();

            foreach (var e in employeesWithProjects)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .Take(10)
                .ToArray();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //09. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ep.Project.Name
                        })
                        .OrderBy(e => e.Name)
                        .ToArray()
                })
                .FirstOrDefault(e => e.EmployeeId == 147);

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var p in employee.Projects)
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString().TrimEnd();
        }

        //10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToArray()
                })
                .ToArray();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.StartDate,
                    p.Description,
                })
                .OrderBy(p => p.Name)
                .ToArray();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString().TrimEnd();
        }

        //12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => departments.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            IQueryable<EmployeeProject> employeeToDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(employeeToDelete);

            Project projectToDelete = context.Projects.Find(2);
            context.Projects.RemoveRange(projectToDelete);
            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(p => new
                {
                    ProjectName = p.Name

                })
                .ToArray();

            foreach (var project in projects)
            {
                sb.AppendLine(project.ProjectName);
            }

            return sb.ToString().TrimEnd(); 
        }

        //15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .Include(x => x.Addresses)
                .FirstOrDefault(x => x.Name == "Seattle");
            var allAddressesIds = town.Addresses.Select(x => x.AddressId).ToList();
            var employees = context.Employees
                .Where(x => x.AddressId.HasValue && allAddressesIds.Contains(x.AddressId.Value))
                .ToList();

            foreach (var emp in employees)
            {
                emp.AddressId = null;
            }

            foreach (var addressId in allAddressesIds)
            {
                var address = context.Addresses
                    .FirstOrDefault(x => x.AddressId == addressId);
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{allAddressesIds.Count} addresses in Seattle were deleted";
        }
    }

}