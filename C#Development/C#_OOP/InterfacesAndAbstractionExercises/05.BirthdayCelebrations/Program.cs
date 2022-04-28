using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthdays> all = new List<IBirthdays>();
            var command = Console.ReadLine();
            while (command != "End")
            {
                var lines = command.Split();
                if (lines[0] == "Citizen")
                {
                    var name = lines[1];
                    var age = int.Parse(lines[2]);
                    var id = lines[3];
                    var birthdate = lines[4];
                    all.Add(new Citizens(name, age, id, birthdate));

                }
                else if (lines[0] == "Pet")
                {
                    var name = lines[1];
                    var birthdate = lines[2];
                    all.Add(new Pet(name, birthdate));
                }

                command = Console.ReadLine();
            }
            int year = int.Parse(Console.ReadLine());

            all.Where(c => c.Birthdate.Year == year)
                .Select(c => c.Birthdate)
                .ToList()
                .ForEach(dt => Console.WriteLine($"{dt:dd/mm/yyyy}"));
        }
    }
}
