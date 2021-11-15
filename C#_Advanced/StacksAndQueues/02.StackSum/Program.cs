using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            Stack<int> stack = new Stack<int>();
            foreach (var item in array)
            {
                stack.Push(int.Parse(item));
            }

            while (true)
            {
                string line = Console.ReadLine();
                var lineSplitted = line.Split();
                string command = lineSplitted[0].ToLower();

                if (command == "end")
                {
                    break;
                }
                else if (command == "add")
                {
                    stack.Push(int.Parse(lineSplitted[1]));
                    stack.Push(int.Parse(lineSplitted[2]));
                }
                else if (command == "remove")
                {
                    int n = int.Parse(lineSplitted[1]);
                    if (stack.Count > n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            int sum = 0;
            while (stack.Count >0)
            {
                int number = stack.Pop();
                sum += number;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
