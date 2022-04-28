using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] threads = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int taskToKill = int.Parse(Console.ReadLine());
            int removed = 0;

            Queue<int> queue = new Queue<int>(threads);
            Stack<int> stack = new Stack<int>(tasks);

            while (queue.Count > 0 && stack.Count > 0)
            {

                if (stack.Peek() == taskToKill)
                {
                    stack.Pop();
                    removed = queue.Peek();

                    break;
                }

                if (queue.Peek() >= stack.Peek())
                {
                    queue.Dequeue();
                    stack.Pop();
                }

                else if (queue.Peek() < stack.Peek())
                {
                    queue.Dequeue();
                }
            }


            Console.WriteLine($"Thread with value {removed} killed task {taskToKill}");
            Console.WriteLine(String.Join(" ", queue));

        }
    }
}
