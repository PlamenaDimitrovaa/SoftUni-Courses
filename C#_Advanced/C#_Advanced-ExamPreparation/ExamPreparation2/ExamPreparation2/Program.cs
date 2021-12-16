using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparation2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var threads = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int taskToKill = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(tasks);
            Queue<int> queue = new Queue<int>(threads);
            var thread = 0;
            var task = 0;
            while (stack.Contains(taskToKill))
            {
                 thread = queue.Peek();
                 task = stack.Peek();

                if (task == taskToKill)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {taskToKill}");
                    break;
                }
                if (thread >= task)
                {
                    queue.Dequeue();
                    stack.Pop();
                }
                else if (thread < task)
                {
                    queue.Dequeue();
                }
            }

            Console.WriteLine(String.Join(" ", queue));

        }
    }
}
