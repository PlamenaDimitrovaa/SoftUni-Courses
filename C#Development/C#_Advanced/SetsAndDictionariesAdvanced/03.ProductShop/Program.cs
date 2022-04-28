using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, double>> dictionary =
                new SortedDictionary<string, Dictionary<string,double>>();

            while (command != "Revision")
            {
                string[] input = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);
                if (!dictionary.ContainsKey(shop))
                {
                    dictionary.Add(shop, new Dictionary<string, double>());
                    dictionary[shop].Add(product, price);
                }
                else
                {
                    dictionary[shop].Add(product, price);
                }

                command = Console.ReadLine();
            }

            foreach (var shop in dictionary)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
