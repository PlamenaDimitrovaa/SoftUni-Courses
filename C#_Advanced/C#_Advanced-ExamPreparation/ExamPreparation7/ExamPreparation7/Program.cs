using System;
using System.Linq;
using System.Collections.Generic;

namespace ExamPreparation7
{
    class Program
    {
        static void Main(string[] args)
        {
            var hatss = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var scarfss = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> hats = new Stack<int>(hatss);
            Queue<int> scarfs = new Queue<int>(scarfss);
            Queue<int> sets = new Queue<int>();

            while (hats.Any() && scarfs.Any())
            {
                var currentHat = hats.Peek();
                var currentScarf = scarfs.Peek();
                if (currentHat > currentScarf)
                {
                    sets.Enqueue(hats.Pop() + scarfs.Dequeue());
                }

                if (currentScarf > currentHat)
                {
                    hats.Pop();
                    continue;
                }

                if (currentScarf == currentHat)
                {
                    scarfs.Dequeue();
                    var hatToIncrease = hats.Pop();
                    hats.Push(hatToIncrease + 1);
                }

            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            foreach (var item in sets)
            {
                Console.Write(item + " ");
            }

        }
    }
}
