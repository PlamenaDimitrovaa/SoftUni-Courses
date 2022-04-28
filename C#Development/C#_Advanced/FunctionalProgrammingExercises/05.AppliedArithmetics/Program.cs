using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            Action<int[]> add = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] += 1;
                }
            };

            Action<int[]> subtract = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] -= 1;
                }
            };

            Action<int[]> multiply = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] *= 2;
                }
            };

            Action<int[]> print = numbers => Console.WriteLine(string.Join(" ", numbers));

            while (command != "end")
            {
                if (command == "add")
                {
                    
                        add(numbers);
                    
                }
                else if (command == "multiply")
                {
                    
                        multiply(numbers);
                    

                }
                else if (command == "subtract")
                {
                    
                        subtract(numbers);
                    
                }
                else if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
