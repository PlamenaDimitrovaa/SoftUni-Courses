using System;
using System.Text.RegularExpressions;

namespace RegularExpressions1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            MatchCollection matchedNames = Regex.Matches(input, regex);

            foreach (Match match in matchedNames)
            {
                Console.Write(match.Value + " ");
            }

            Console.WriteLine();
        }
    }
}
