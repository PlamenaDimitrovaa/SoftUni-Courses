using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").Select(double.Parse).Select(x => x * 1.2);
            foreach (var item in input)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
