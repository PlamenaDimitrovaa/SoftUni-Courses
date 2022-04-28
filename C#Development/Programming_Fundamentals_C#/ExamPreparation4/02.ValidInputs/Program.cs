using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.ValidInputs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> collection = new Dictionary<string, string>();
            string pattern = @"\|(?<boss>[A-Z]{4,})\|:#(?<title>[A-z]{1,} [A-z]{1,})#";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    foreach (Match item in matches)
                    {
                        Console.WriteLine($"{item.Groups["boss"].Value}, The {item.Groups["title"].Value}");
                        Console.WriteLine($">> Strength: {item.Groups["boss"].Length}");
                        Console.WriteLine($">> Armor: {item.Groups["title"].Length}");
                    }
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }



        }
    }
}
