using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            while (true)
            {
                var tokens = Console.ReadLine().Split();
                if (tokens[0] == "END")
                {
                    break;
                }

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];
                persons.Add(new Person(name, age, town));
            }

            var index = int.Parse(Console.ReadLine()) - 1;
            var equal = 0;
            var notEqual = 0;
            foreach (var person in persons)
            {
                if (persons[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }

            if (equal <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {notEqual} {persons.Count}");
            }
        }
    }
}
