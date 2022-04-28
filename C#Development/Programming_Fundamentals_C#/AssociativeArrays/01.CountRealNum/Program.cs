using System;
using System.Collections.Generic;
using System.Linq;

namespace PlamenaAsen
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> dictionary = new SortedDictionary<double, int>();

            var numberAsArray = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < numberAsArray.Length; i++)
            {
                if (!dictionary.ContainsKey(numberAsArray[i]))
                {
                    dictionary.Add(numberAsArray[i], 0);
                }

                dictionary[numberAsArray[i]]++;

            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
