using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //char[] delimiterChars = {'.', '\\'};
            // string[] input = Console.ReadLine().Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            //string name = input[3];
            //string extension = input[4];
            //Console.WriteLine($"File name: {name}");
            //Console.WriteLine($"File extension: {extension}");

            List<string> input = Console.ReadLine()
                 .Split(("\\"))
                 .ToList();

            string[] value = input[input.Count - 1].Split('.');

            Console.WriteLine($"File name: {value[0]}");
            Console.WriteLine($"File extension: {value[1]}");

        }
    }
}
