using System;
using System.Linq;

namespace _04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var lake = new Lake(input);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
