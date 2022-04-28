using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FirstProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var water = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            var flour = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            var queueWater = new Queue<double>(water);
            var stackFlour = new Stack<double>(flour);
            var croissant = 0;
            var muffin = 0;
            var baguette = 0;
            var bagel = 0;

            while (queueWater.Any() && stackFlour.Any())
            {
                var mix = queueWater.Peek() + stackFlour.Peek();

                if (((queueWater.Peek() * 100) / mix) == 50 && ((stackFlour.Peek() * 100) / mix) == 50)
                {
                    croissant++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else if (((queueWater.Peek() * 100) / mix) == 40 && ((stackFlour.Peek() * 100) / mix) == 60)
                {
                    muffin++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else if (((queueWater.Peek() * 100) / mix) == 30 && ((stackFlour.Peek() * 100) / mix) == 70)
                {
                    baguette++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else if (((queueWater.Peek() * 100) / mix) == 20 && ((stackFlour.Peek() * 100) / mix) == 80)
                {
                    bagel++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else
                {
                    if (stackFlour.Peek() > queueWater.Peek())
                    {
                        croissant++;
                        var toInsert = stackFlour.Pop() - queueWater.Dequeue();
                        stackFlour.Push(toInsert);
                    }
                }
            }

            var dictionary = new Dictionary<string, double>();
            dictionary.Add("Croissant", croissant);
            dictionary.Add("Muffin", muffin);
            dictionary.Add("Baguette", baguette);
            dictionary.Add("Bagel", bagel);

            foreach (var item in dictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

            if (queueWater.Any())
            {
                Console.WriteLine($"Water left: {string.Join(", ", queueWater)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (stackFlour.Any())
            {
                Console.WriteLine($"Flour left: {string.Join(", ", stackFlour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
