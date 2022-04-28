using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaxAndMinElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                int num = int.Parse(input[0]);

                if (num == 1)
                {
                    int numToPush = int.Parse(input[1]);
                    stack.Push(numToPush);

                }
                else if (num == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();

                    }
                }

                else if(num == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    
                }
                else if (num == 4)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                   
                }
            }

            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
