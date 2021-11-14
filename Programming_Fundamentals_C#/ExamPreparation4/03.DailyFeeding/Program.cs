
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.DailyFeeding
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var dictionary1 = new Dictionary<string, int>();
            var dictionary2 = new Dictionary<string, int>();

            while (command != "EndDay")
            {
                var inputInfo = command.Split(new char[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                string action = inputInfo[0];

                if (action == "Add")
                {
                    string animalName = inputInfo[1];
                    int neededFoodQty = int.Parse(inputInfo[2]);
                    string area = inputInfo[3];
                    if (!dictionary1.ContainsKey(animalName))
                    {
                        dictionary1.Add(animalName, neededFoodQty);


                        if (!dictionary2.ContainsKey(area))
                        {
                            dictionary2.Add(area, 0);
                        }

                        dictionary2[area]++;

                    }
                    else
                    {
                        dictionary1[animalName] += neededFoodQty;

                    }
                }

                else if (action == "Feed")
                {
                    string animalName = inputInfo[1];
                    int food = int.Parse(inputInfo[2]);

                    if (dictionary1.ContainsKey(animalName))
                    {
                        dictionary1[animalName] = dictionary1[animalName] - food;
                    }
                    else
                    {
                        break;
                    }


                    if (dictionary1[animalName] <= 0)
                    {
                        Console.WriteLine($"{animalName} was successfully fed");
                        dictionary1.Remove(animalName);


                    }

                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Animals:");
            foreach (var item in dictionary1.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}g");
            }
            Console.WriteLine("Areas with hungry animals:");
            foreach (var item in dictionary2.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
