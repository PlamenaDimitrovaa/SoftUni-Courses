using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> nameLength = (name, length) => name.Length <= length;
            int maxLengthName = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split()
                .Where(x => nameLength(x, maxLengthName))
                .ToArray();

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
