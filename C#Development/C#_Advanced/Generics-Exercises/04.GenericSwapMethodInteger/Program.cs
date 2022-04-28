using System;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<int>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Add(input);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}
