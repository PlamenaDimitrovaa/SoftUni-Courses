using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] divNums = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();
            int[] allNumbers = Enumerable.Range(1, n).ToArray();
            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var number in divNums)
            {
                predicates.Add(x => x % number == 0);
            }

            foreach (var currentNumber in allNumbers)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(currentNumber))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write(currentNumber + " ");
                }
            }
        }
    }
}
