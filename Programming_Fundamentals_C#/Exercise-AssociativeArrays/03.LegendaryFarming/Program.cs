using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> items = new Dictionary<string, int>
            {
                {"shards", 0 },
                {"fragments", 0 },
                {"motes", 0 }
            };
            Dictionary<string, int> junks = new Dictionary<string, int>();
            bool isFound = false;
            while (!isFound)
            {
                string[] input = Console.ReadLine().Split();
                for (int i = 0; i < input.Length; i += 2)
                {
                    int value = int.Parse(input[i]);
                    string element = input[i + 1].ToLower();

                    if (element == "shards")
                    {
                        items["shards"] += value;
                    }
                    else if (element == "fragments")
                    {
                        items["fragments"] += value;
                    }
                    else if (element == "motes")
                    {
                        items["motes"] += value;
                    }
                    else
                    {
                        if (!junks.ContainsKey(element))
                        {
                            junks.Add(element, 0);
                        }

                        junks[element] += value;
                    }


                    if (items["shards"] >= 250 || items["fragments"] >= 250 || items["motes"] >= 250)
                    {
                        isFound = true;
                        break;
                    }
                }
                
            }

            if (items["shards"] >= 250)
            {
                items["shards"] -= 250;
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if(items["fragments"] >= 250)
            {
                items["fragments"] -= 250;
                Console.WriteLine("Valanyr obtained!");
            }
            else if (items["motes"] >= 250)
            {
                items["motes"] -= 250;
                Console.WriteLine("Dragonwrath obtained!");
            }

            foreach (var item in items.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junks.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
