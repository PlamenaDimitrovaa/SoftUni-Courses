using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<decimal>() { grade });
                }
                else
                {
                    dict[name].Add(grade);
                }
            }

            foreach (var name in dict)
            {
                Console.WriteLine($"{name.Key} -> {string.Join(" ", name.Value.Select(x=> $"{x:F2}"))} (avg: {name.Value.Average():F2})");
            }
        }
    }
}
