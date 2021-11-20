using System;
using System.Linq;
using System.Collections.Generic;

namespace Exam_StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] roses = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(lilies);
            Queue<int> queue = new Queue<int>(roses);
            int count = 0;
            int sum = 0;
            int store = 0;
            while (stack.Count > 0 && queue.Count > 0)
            {
                sum = stack.Peek() + queue.Peek();

                if (sum == 15)
                {
                    count++;
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (sum > 15)
                {
                    int decreased = stack.Pop();
                    stack.Push(decreased - 2);
                }
                else if (sum < 15)
                {
                    store += stack.Pop() + queue.Dequeue();
                }
            }

            count += store / 15;

            if (count >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {count} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - count} wreaths more!");
            }

        }
    }
}
