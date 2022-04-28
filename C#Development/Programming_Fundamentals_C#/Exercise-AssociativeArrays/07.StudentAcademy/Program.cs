using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, List<double>>();
            string studentName;
            double studentGrade = 0;


            for (int i = 0; i < n; i++)
            {
                 studentName = Console.ReadLine();
               studentGrade = double.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(studentName))
                {
                    dictionary.Add(studentName, new List<double>());
                }
                dictionary[studentName].Add(studentGrade);
            }

            foreach (var item in dictionary.OrderByDescending(x => x.Value.Average()))
            {
                if (item.Value.Average() >= 4.5)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
                }
            }
        }
    }
}
