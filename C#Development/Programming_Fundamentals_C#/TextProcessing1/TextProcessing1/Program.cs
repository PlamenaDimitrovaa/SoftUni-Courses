using System;
using System.Linq;

namespace TextProcessing1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string reversedWord = "";
            while (input != "end")
            {
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversedWord += input[i];
                }

                Console.WriteLine($"{input} = {reversedWord}");

                reversedWord = "";

                input = Console.ReadLine();
            }

        }
    }
}
