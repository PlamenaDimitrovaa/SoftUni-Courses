using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var regex = @"\+359(?<separator>(.?)(-?))2(\k<separator>(.?)(-?))(?<firstgroup>[0-9]{3})(\k<separator>(.?)(-?))(?<secondgroup>[0-9]{4})";

            var phoneMatches = Regex.Matches(input, regex);

            var matchedPhones = phoneMatches.Cast<Match>().Select(a => a.Value.Trim()).ToArray();

            Console.WriteLine(String.Join(", ", matchedPhones));
        }
    }
}
