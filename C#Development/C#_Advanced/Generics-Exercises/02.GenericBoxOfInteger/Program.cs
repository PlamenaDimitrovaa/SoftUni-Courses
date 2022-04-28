using System;

namespace _02.GenericBoxOfInteger
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

            Console.WriteLine(box);
        }
    }
}
