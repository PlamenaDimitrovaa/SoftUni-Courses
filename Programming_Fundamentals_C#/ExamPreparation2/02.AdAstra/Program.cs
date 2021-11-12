using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double calories = 0;
            string pattern = @"([#||])(?<itemName>[A-z\s]{1,})\1(?<expDate>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>[0-9]{1,5})\1";
            double days = 0;
       

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                calories += int.Parse(match.Groups["calories"].Value);
            }

            days = calories / 2000;

            Console.WriteLine($"You have food to last you for: {Math.Floor(days)} days!");

            foreach (Match item in matches)
            {             

                    Console.WriteLine($"Item: {item.Groups["itemName"]}, Best before: {item.Groups["expDate"]}, Nutrition: {item.Groups["calories"]}");
                
            }
        }
    }
}
