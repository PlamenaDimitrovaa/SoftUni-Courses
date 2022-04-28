using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int[]> pirates = new Dictionary<string, int[]>();

            while (input != "Sail")
            {
                string[] inputInfo = input.Split("||");
                string city = inputInfo[0];
                int population = int.Parse(inputInfo[1]);
                int gold = int.Parse(inputInfo[2]);

                if (!pirates.ContainsKey(city))
                {
                    pirates.Add(city, new int[] { population, gold });
                }
                else
                {
                    int[] currentValues = pirates[city];
                    currentValues[0] += population;
                    currentValues[1] += gold;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split("=>");
                string command = inputInfo[0];

                if (command == "Plunder")
                {
                    string city = inputInfo[1];
                    int people = int.Parse(inputInfo[2]);
                    int gold = int.Parse(inputInfo[3]);

                    int[] values = pirates[city];
                    values[0] -= people;
                    values[1] -= gold;
                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (values[0] == 0 || values[1] == 0)
                    {
                        Console.WriteLine($"{city} has been wiped off the map!");
                        pirates.Remove(city);
                    }
                }
                else if (command == "Prosper")
                {
                    string city = inputInfo[1];
                    int gold = int.Parse(inputInfo[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        input = Console.ReadLine();
                        continue;
                    }

                    int[] values = pirates[city];
                    values[1] += gold;

                    Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {values[1]} gold.");
                }

                input = Console.ReadLine();
            }

            if (pirates.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {pirates.Count} wealthy settlements to go to:");
                foreach (var p in pirates.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{p.Key} -> Population: {p.Value[0]} citizens, Gold: {p.Value[1]} kg");
                }

            }
        }
    }
}
