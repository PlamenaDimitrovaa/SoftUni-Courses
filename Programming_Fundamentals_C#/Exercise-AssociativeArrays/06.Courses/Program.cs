using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();


            while (input != "end")
            {
                string[] inputInfo = input.Split(" : ");

                string courseName = inputInfo[0];
                string studentName = inputInfo[1];

                if (!dictionary.ContainsKey(courseName))
                {
                    dictionary.Add(courseName, new List<string>());

                }
                
                    dictionary[courseName].Add(studentName);
                

                input = Console.ReadLine();
            }
            
            foreach (var item in dictionary.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach (var element in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {element}");
                }
            }

            
        }
    }
}
