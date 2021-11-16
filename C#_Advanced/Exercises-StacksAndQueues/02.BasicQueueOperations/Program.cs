using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numToEnqueue = input[0];
            int numToDequeue = input[1];
            int numToSearch = input[2];
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);

            }

            if (queue.Count > 0)
            {
                for (int i = 0; i < numToDequeue; i++)
                {
                    queue.Dequeue();

                    if (queue.Count <= 0)
                    {
                        Console.WriteLine("0");
                    }

                }

                if (queue.Contains(numToSearch))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    if (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Min());

                    }
                }

            }
        }
    }
}
