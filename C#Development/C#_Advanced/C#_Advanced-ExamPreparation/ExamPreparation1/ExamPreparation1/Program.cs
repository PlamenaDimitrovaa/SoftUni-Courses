using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation1
{
    class Program
    {
        static void Main(string[] args)
        {
            //01.MASTERCHEF
            var ingredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var freshness = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(ingredients);
            Stack<int> stack = new Stack<int>(freshness);
            int sauce = 0;
            int salad = 0;
            int cake = 0;
            int lobster = 0;

            while (queue.Count > 0 && stack.Count > 0)
            {
                var ingredient = queue.Peek();
                var fresh = stack.Peek();
                var freshnessLevel = ingredient * fresh;
                if (freshnessLevel == 150)
                {
                    sauce++;
                    queue.Dequeue();
                    stack.Pop();
                }
                else if (freshnessLevel == 250)
                {
                    salad++;
                    queue.Dequeue();
                    stack.Pop();
                }
                else if (freshnessLevel == 300)
                {
                    cake++;
                    queue.Dequeue();
                    stack.Pop();
                }
                else if (freshnessLevel == 400)
                {
                    lobster++;
                    queue.Dequeue();
                    stack.Pop();
                }
                else if (ingredient == 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    stack.Pop();
                    ingredient += 5;
                    queue.Dequeue();
                    queue.Enqueue(ingredient);
                }
            }

            if (sauce > 0 && salad > 0 && cake > 0 && lobster > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
                Console.WriteLine($"# Chocolate cake --> {cake}");
                Console.WriteLine($"# Dipping sauce --> {sauce}");
                Console.WriteLine($"# Green salad --> {salad}");
                Console.WriteLine($"# Lobster --> {lobster}");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (queue.Any())
                {
                    Console.WriteLine($"Ingredients left: {queue.Sum()}");

                }

                if (cake > 0)
                {
                    Console.WriteLine($"# Chocolate cake --> {cake}");

                }
                if (sauce > 0)
                {
                    Console.WriteLine($"# Dipping sauce --> {sauce}");

                }
                if (salad > 0)
                {
                    Console.WriteLine($"# Green salad --> {salad}");

                }             
                if (lobster > 0)
                {
                    Console.WriteLine($"# Lobster --> {lobster}");

                }
            }
        }
    }
}
