using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            while (text.Contains(word))
            {
               text = text.Remove(text.IndexOf(word), word.Length);
            }
            Console.WriteLine(text);
        }
    }
}
