using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffects = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] bombCasings = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            bool success = false;

            Queue<int> effects = new Queue<int>(bombEffects);
            Stack<int> casings = new Stack<int>(bombCasings);
            int currentSum = 0;

            Dictionary<string, int> bombType = new Dictionary<string, int>();
            bombType.Add("Datura Bombs", 0);
            bombType.Add("Cherry Bombs", 0);
            bombType.Add("Smoke Decoy Bombs", 0);

            while (effects.Any() && casings.Any())
            {
                currentSum = effects.Peek() + casings.Peek();

                if (currentSum == 40 || currentSum == 60 || currentSum == 120)
                {
                    int firstBombEffect = effects.Dequeue();
                    int lastBombCasing = casings.Pop();

                    if (currentSum == 40)
                    {
                       
                            bombType["Datura Bombs"]++;
                        
                    }
                    else if (currentSum == 60)
                    {
                       
                            bombType["Cherry Bombs"]++;
                        
                    }
                    else if (currentSum == 120)
                    {
                      
                            bombType["Smoke Decoy Bombs"]++;
                        
                    }

                }
                else
                {
                    int decrease = casings.Pop();
                    casings.Push(decrease - 5);
                }

                if (bombType["Datura Bombs"] == 3 && bombType["Cherry Bombs"] == 3 && bombType["Smoke Decoy Bombs"] == 3)
                {
                    success = true;
                    break;
                }
            }
            if (success)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count <= 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ", effects)}");
            }

            if (casings.Count <= 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", casings)}");
            }

            foreach (var item in bombType.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
              
            }

        }
    }
}
