using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->").ToArray();
                string plant = input[0];
                double rarity = double.Parse(input[1]);
                if (!plants.ContainsKey(plant))
                {
                    plants.Add(plant, new List<double>());
                    plants[plant].Add(rarity);
                }
                else
                {
                    plants[plant][0] += rarity;
                }

            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Exhibition")
                {
                    break;
                }
                string[] command = input.Split(new char[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                string plant = command[1];
                if (!plants.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    continue;
                }

                if (command[0] == "Rate")
                {

                    double rating = double.Parse(command[2]);

                    plants[plant].Add(rating);
                }
                else if (command[0] == "Update")
                {
                    double rarity = double.Parse(command[2]);

                    plants[plant][0] = rarity;

                }
                else if (command[0] == "Reset")
                {
                    plants[plant].RemoveRange(1, plants[plant].Count - 1);

                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            foreach (var item in plants)
            {

                double rarity = item.Value[0];

                item.Value.RemoveAt(0);

                int count = item.Value.Count;

                double sum = item.Value.Sum();

                if (sum != 0)
                {
                    sum /= count;
                }
                item.Value.Clear();
                item.Value.Add(rarity);
                item.Value.Add(sum);

            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]).ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine($"- {item.Key}; Rarity: {(int)item.Value[0]}; Rating: {item.Value[1]:f2}");
            }

            //int n = int.Parse(Console.ReadLine());
            //Dictionary<string, int> dictionary = new Dictionary<string, int>();
            //var rating = new Dictionary<string, List<double>>();

            //for (int i = 0; i < n; i++)
            //{
            //    var input = Console.ReadLine().Split("<->");

            //    string name = input[0];

            //    int rarity = int.Parse(input[1]);

            //    if (!dictionary.ContainsKey(name))
            //    {
            //        dictionary.Add(name, rarity);
            //        rating.Add(name, new List<double>());
            //    }
            //    else
            //    {
            //        dictionary[name] = rarity;
            //    }
            //}

            //string command = Console.ReadLine();

            //while (command != "Exhibition")
            //{
            //    var inputInfo = command.Split(new string[] { ": ", " - " }, StringSplitOptions.None);

            //    string action = inputInfo[0];

            //    if (action == "Rate")
            //    {
            //        string name = inputInfo[1];
            //        int givenRating = int.Parse(inputInfo[2]);

            //        if (!rating.ContainsKey(name))
            //        {
            //            rating.Add(name, new List<double> { givenRating });

            //        }
            //        else
            //        {
            //            rating[name].Add(givenRating);
            //        }
            //    }

            //    else if (action == "Update")
            //    {
            //        string name = inputInfo[1];
            //        int newRarity = int.Parse(inputInfo[2]);

            //        if (dictionary.ContainsKey(name))
            //        {
            //            dictionary[name] = newRarity;
            //        }
            //    }
            //    else if (action == "Reset")
            //    {
            //        string name = inputInfo[1];

            //        if (rating.ContainsKey(name))
            //        {
            //            rating[name].Clear();
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("error");
            //    }

            //    command = Console.ReadLine();
            //}

            //Console.WriteLine("Plants for the exhibition:");

            //var sorted = dictionary
            //  .OrderByDescending(x => x.Value)
            //  .ThenByDescending(x => rating[x.Key].Count > 0
            //      ? rating[x.Key].Sum() / rating[x.Key].Count
            //      : 0.0);
            //foreach (var (plant, rarity) in sorted)
            //{
            //    var averageRating = rating[plant].Count > 0
            //        ? rating[plant].Sum() / rating[plant].Count
            //        : 0.0;
            //    Console.WriteLine($"- {plant}; Rarity: {rarity}; Rating: {averageRating:F2}");
            //}
        }
    }
}
