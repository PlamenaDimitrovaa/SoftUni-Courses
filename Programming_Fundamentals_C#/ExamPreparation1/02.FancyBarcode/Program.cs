using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcode
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfBarcodes = int.Parse(Console.ReadLine());
            string pattern = @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+";
            string digitsPattern = "[0-9]";

            for (int i = 0; i < countOfBarcodes; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                MatchCollection matches = Regex.Matches(input, digitsPattern);
                Console.Write("Product group: ");

                if (matches.Count == 0)
                {
                    Console.WriteLine("00");
                    continue;
                }

                foreach (Match item in matches)
                {
                    Console.Write(item.Value);
                }

                Console.WriteLine();

            }

        }
    }
}
