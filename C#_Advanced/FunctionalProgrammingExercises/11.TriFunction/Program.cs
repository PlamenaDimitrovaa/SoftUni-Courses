using System;
using System.Linq;
using System.Collections.Generic;

namespace _11.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            Func<string, int, bool> isLargerOrEqualToNameASCII = (name, asciiSum)
                => name.Sum(x => x) >= asciiSum;

            Func<List<string>, int, Func<string, int, bool>, string> desiredName = (names, number, func)
                => names.FirstOrDefault(x => func(x,number));

            string name = desiredName(names, n, isLargerOrEqualToNameASCII);
            Console.WriteLine(name);

        }
    }
}
