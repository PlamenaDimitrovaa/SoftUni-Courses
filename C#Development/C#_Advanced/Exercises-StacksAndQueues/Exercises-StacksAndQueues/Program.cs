using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises_StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            int numsToPush = int.Parse(input[0]);
            int numsToPop = int.Parse(input[1]);
            int numToSearch = int.Parse(input[2]);

            var numbers = Console.ReadLine().Split();
        
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numsToPush; i++)
            {
                stack.Push(int.Parse(numbers[i]));
            }

            if (stack.Count > 0)
            {
                for (int i = 0; i < numsToPop; i++)
                {
                    stack.Pop();

                     if (stack.Count <= 0)
                    {
                        Console.WriteLine("0");
                    }

                }

                if (stack.Contains(numToSearch))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());

                    }
                }

            }

          
        }

    }
}

