using System;
using System.Collections.Generic;
using System.Linq;

namespace _08
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            string companyName;
            string employeeId;
            while (input != "End")
            {
                string[] inputInfo = input.Split(" -> ");

                companyName = inputInfo[0];
                employeeId = inputInfo[1];

                if (!dictionary.ContainsKey(companyName))
                {
                    dictionary.Add(companyName, new List<string>());
                }

                if (!dictionary[companyName].Contains(employeeId))
                {
                    dictionary[companyName].Add(employeeId);
                }



                input = Console.ReadLine();

            }

            foreach (var item in dictionary.OrderBy(item => item.Key))
            {
                Console.WriteLine($"{item.Key}");

                foreach (var element in item.Value)
                {
                    Console.WriteLine($"-- {element}");
                }
            }

        }
    }
}
