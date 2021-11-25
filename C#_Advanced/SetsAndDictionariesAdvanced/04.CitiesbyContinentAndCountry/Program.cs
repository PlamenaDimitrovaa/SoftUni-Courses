using System;
using System.Collections.Generic;

namespace _04.CitiesbyContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> dictionary =
                new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string town = input[2];

                if (!dictionary.ContainsKey(continent))
                {
                    dictionary.Add(continent, new Dictionary<string, List<string>>());
                    dictionary[continent].Add(country, new List<string> { town });
                   
                }
                else if (!dictionary[continent].ContainsKey(country))
                {
                    dictionary[continent].Add(country, new List<string> { town });

                }
                else
                {
                    dictionary[continent][country].Add(town);
                }

              
            }

            foreach (var continent in dictionary)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
