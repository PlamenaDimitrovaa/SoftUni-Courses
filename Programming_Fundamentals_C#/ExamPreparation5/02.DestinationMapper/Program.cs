using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            int sum = 0;
            string pattern = @"(?<tag>[=\/])(?<name>[A-Z][A-Za-z]{2,})\1";

            MatchCollection matches = Regex.Matches(input, pattern);

            List<string> result = new List<string>();
            foreach (Match match in matches)
            {
                int length = match.Groups["name"].Length;
                 sum += length;
                result.Add(match.Groups["name"].Value);

            }
           
                Console.WriteLine($"Destinations: " + String.Join(", ", result));
                
                Console.WriteLine($"Travel Points: {sum}");

        }
    }
}
