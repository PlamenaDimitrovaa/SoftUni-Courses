using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in input)
                {
                    set.Add(item);
                }
            }
            foreach (var item in set)
            {
                Console.Write(item + " ");

            }
        }
    }
}
