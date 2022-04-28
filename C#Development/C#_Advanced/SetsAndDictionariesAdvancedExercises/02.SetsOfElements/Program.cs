using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int n = numbers[0];
            int m = numbers[1];
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();
            List<int> list = new List<int>();
            for (int i = 0; i < n+m; i++)
            {
                int input = int.Parse(Console.ReadLine());
                list.Add(input);          
            }

            for (int i = 0; i < n; i++)
            {
                first.Add(list[i]);
            }
            for (int i = n; i < list.Count; i++)
            {
                second.Add(list[i]);
            }

            for (int i = 0; i < n + m; i++)
            {
                if (first.Contains(list[i]) && second.Contains(list[i]))
                {
                    result.Add(list[i]);
                }
            }

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
    
        }
    }
}
