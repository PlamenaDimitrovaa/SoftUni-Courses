using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation11
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredientss = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var freshnessLevel = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> ingredients = new Queue<int>(ingredientss);
            Stack<int> freshness = new Stack<int>(freshnessLevel);
            int dippingSauce = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobster = 0;

            while (ingredients.Any() && freshness.Any())
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                var totalFreshnessLevel = ingredients.Peek() * freshness.Peek();

                if (totalFreshnessLevel == 150)
                {
                    dippingSauce++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshnessLevel == 250)
                {
                    greenSalad++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshnessLevel == 300)
                {
                    chocolateCake++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshnessLevel == 400)
                {
                    lobster++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    var increase = ingredients.Dequeue();
                    ingredients.Enqueue(increase + 5);
                }
            }

            if (dippingSauce > 0 && greenSalad > 0 && chocolateCake > 0 && lobster > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            if (chocolateCake > 0)
            {
                Console.WriteLine($" # Chocolate cake --> {chocolateCake}");
            }

            if (dippingSauce > 0)
            {
                Console.WriteLine($" # Dipping sauce --> {dippingSauce}");
            }

            if (greenSalad > 0)
            {
                Console.WriteLine($" # Green salad --> {greenSalad}");
            }

            if (lobster > 0)
            {
                Console.WriteLine($" # Lobster --> {lobster}");
            }
        }
    }
}
