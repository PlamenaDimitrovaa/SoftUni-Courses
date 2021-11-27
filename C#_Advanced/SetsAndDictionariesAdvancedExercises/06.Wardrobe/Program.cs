using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> dict =
                new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] clothes = input[1].Split(',');

                if (!dict.ContainsKey(color))
                {
                    dict.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!dict[color].ContainsKey(item))
                    {
                        dict[color].Add(item, 0);
                    }
                    dict[color][item]++;
                }
            }

            string[] targetCloth = Console.ReadLine().Split();

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var element in item.Value)
                {
                    if (element.Key == targetCloth[1] && item.Key == targetCloth[0])
                    {
                        Console.WriteLine($"* {element.Key} - {element.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {element.Key} - {element.Value}");

                    }
                }
            }

        }
    }
}
