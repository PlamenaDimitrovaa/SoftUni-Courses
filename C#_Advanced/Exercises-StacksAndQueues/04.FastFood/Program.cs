using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(orders);
            int sum = 0;
            Console.WriteLine(queue.Max());


            while (queue.Count > 0)
            {
                int first = queue.Peek();
                sum += first;

                if (sum <= foodQuantity)
                {
                    queue.Dequeue();
                }

                else
                {
                    int[] array = queue.ToArray();
                    Console.WriteLine($"Orders left: {String.Join(" ", array)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }

    }
}