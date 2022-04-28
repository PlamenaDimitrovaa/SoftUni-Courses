using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var upperLetter = input.Where(word => char.IsUpper(word[0]));

            foreach (var item in upperLetter)
            {
                Console.WriteLine(item);
            }

        }     
        
    }
}
