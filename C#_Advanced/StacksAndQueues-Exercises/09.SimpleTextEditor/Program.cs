using System;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = String.Empty;
            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                int command = int.Parse(input[0]);

                if (command == 1)
                {
                    string stringToAppend = input[1];
                    stack.Push(result);
                    result += stringToAppend;

                }
                else if(command == 2)
                {
                    stack.Push(result);
                    int countToRemove = int.Parse(input[1]);
                    if (result.Length >= countToRemove)
                    {
                        string substringToRemove = string.Empty;
                        for (int j = result.Length - countToRemove; j < result.Length; j++)
                        {
                            substringToRemove += result[j];
                        }

                        result = result.Replace(substringToRemove, "");
                    }
                    
                }
                else if(command == 3)
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(result[index - 1]);
                }
                else if(command == 4)
                {
                    if (stack.Count > 0)
                    {
                        result = stack.Pop();
                    }
                    else
                    {
                        result = String.Empty;
                    }
                }

            }
        }
    }
}
