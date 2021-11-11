using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> result = new List<string>();

            string pattern = "(@(?<firstName>[A-Za-z]{3,})@{2}(?<secondName>[A-Za-z]{3,})@)|(#(?<firstName>" +
                "[A-Za-z]{3,})#{2}(?<secondName>[A-Za-z]{3,})#)";

            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string firstValue = match.Groups["firstName"].Value;
                string secondValue = match.Groups["secondName"].Value;
                string reversedValue = string.Join("", match.Groups["secondName"].Value.Reverse());

                if (firstValue == reversedValue)
                {
                    result.Add($"{firstValue} <=> {secondValue}");
                }
            }

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }

            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            if (result.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }

            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ", result));
            }
        }
    }
}
