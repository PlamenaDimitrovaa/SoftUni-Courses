using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string input = Console.ReadLine();
            bool isOdd = true;
            string currentElement = "";
            while (input != "stop")
            {
                if (isOdd)
                {
                    if (!dictionary.ContainsKey(input))
                    {
                        dictionary.Add(input, 0);
                    }

                    currentElement = input;

                    isOdd = false;
                }

                else
                {
                    int value = int.Parse(input);

                    dictionary[currentElement] += value;
                    isOdd = true;
                }

                input = Console.ReadLine();
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
