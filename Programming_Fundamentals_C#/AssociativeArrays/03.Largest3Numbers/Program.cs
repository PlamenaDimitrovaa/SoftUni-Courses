using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(n => n).Take(3).ToArray();

            Console.WriteLine(String.Join(" ", numbers));


        }
    }
}
