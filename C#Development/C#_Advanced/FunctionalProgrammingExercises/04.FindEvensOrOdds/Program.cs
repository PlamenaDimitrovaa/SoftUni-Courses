using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int first = int.Parse(input[0]);
            int second = int.Parse(input[1]);
            string evenOrOdd = Console.ReadLine();
            List<int> odd = new List<int>();
            List<int> even = new List<int>();

            for (int i = first; i <= second; i++)
            {
                if (i % 2 == 0)
                {
                    even.Add(i);
                }
                else if (i % 2 != 0)
                {
                    odd.Add(i);
                }
            }

            if (evenOrOdd == "even")
            {
                Console.WriteLine(String.Join(" ", even));
            }
            else if (evenOrOdd == "odd")
            {
                Console.WriteLine(String.Join(" ", odd));

            }
        }
    }
}
