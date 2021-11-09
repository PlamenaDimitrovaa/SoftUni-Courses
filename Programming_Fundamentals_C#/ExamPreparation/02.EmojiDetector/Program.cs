using System;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"([:*])\1([A-Z][a-z]{2,})\1{2}");
            long coolThreshold = 1;

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    coolThreshold *= input[i] - 48;
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");

            MatchCollection matches = regex.Matches(input);

            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in matches)
            {
                int coolness = 0;
                string emoji = match.Groups[2].Value;

                for (int i = 0; i < emoji.Length; i++)
                {
                    coolness += emoji[i];
                }


                if (coolness > coolThreshold)
                {
                    Console.WriteLine(match.Value);
                }
            }

        }
    }
}
