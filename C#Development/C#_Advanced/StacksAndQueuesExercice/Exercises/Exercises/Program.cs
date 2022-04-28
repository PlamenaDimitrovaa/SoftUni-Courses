using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] waterCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupCapacity);
            Stack<int> bottles = new Stack<int>(waterCapacity);
            int totalWasterWater = 0;
            

            while (cups.Any() && bottles.Any())
            {
                int currentCup = cups.Dequeue();

                while (currentCup > 0 && bottles.Any())
                {
                    int currentBottle = bottles.Pop();
                    currentCup -= currentBottle;
                    if (currentCup < 0)
                    {
                        totalWasterWater += Math.Abs(currentCup);

                    }
                }
            }

            if (cups.Any())
            {
                Console.WriteLine($"Cups: {String.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {totalWasterWater}");

        }
    }
}
