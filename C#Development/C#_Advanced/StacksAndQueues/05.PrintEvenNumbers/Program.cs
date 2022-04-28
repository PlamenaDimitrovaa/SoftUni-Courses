using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Queue<int> evenNumbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Where(i => i % 2 == 0));
            // Console.WriteLine(string.Join(", ", evenNumbers));

            var input = Console.ReadLine().Split();
            Queue<int> queue = new Queue<int>();

            foreach (var item in input)
            {
                queue.Enqueue(int.Parse(item));
            }

            int count = queue.Count();

            for (int i = 0; i < count; i++)
            {
                if (queue.Peek() % 2 == 1)
                {
                    queue.Dequeue();
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                }

            }
            Console.WriteLine(string.Join(", ", queue));


        }
    }
}