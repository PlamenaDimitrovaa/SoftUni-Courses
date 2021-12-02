using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.FilterByAge
{
    class Person
    {
        public string Name;
        public int Age;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(", ");
                var person = new Person();
                person.Name = line[0];
                person.Age = int.Parse(line[1]);
                people.Add(person);
            }

            var filterName = Console.ReadLine();
            var ageToCompate = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = p => true;
            if (filterName == "younger")
            {
                filter = p => p.Age <= ageToCompate;
            }
            else if (filterName == "older")
            {
                filter = p => p.Age >= ageToCompate;
            }

            var filteredPeople = people.Where(filter);

            var printName = Console.ReadLine();
            Func<Person, string> printFunc = p => p.Name + " - " + p.Age;

            if (printName == "name age")
            {
                printFunc = p => p.Name + " - " + p.Age;
            }
            else if (printName == "name")
            {
                printFunc = p => p.Name;
            }
            else if (printName == "age")
            {
                printFunc = p => p.Age.ToString();
            }

            var results = filteredPeople.Select(printFunc);

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }
}
