using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _05.SchoolTeams
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var girlsCombination = new string[3];
            var girlsCombinations = new List<string[]>();
            GenerateCombinations(0, 0, girls, girlsCombination, girlsCombinations);

            var boys = Console.ReadLine().Split(", ");
            var boysCombination = new string[2];
            var boysCombinations = new List<string[]>();
            GenerateCombinations(0, 0, boys, boysCombination, boysCombinations);

            PrintFinalCombs(girlsCombinations, boysCombinations);
        }

        private static void PrintFinalCombs(List<string[]> girlsCombinations, List<string[]> boysCombinations)
        {
            foreach (var girlComb in girlsCombinations)
            {
                foreach(var boyComb in boysCombinations)
                {
                    Console.WriteLine($"{string.Join(", ", girlComb)}, {string.Join(", ", boyComb)}");
                }
            }
        }

        private static void GenerateCombinations(int idx, int start, string[] elements, string[] comb, List<string[]> combs)
        {
            if(idx >= comb.Length) 
            {
                combs.Add(comb.ToArray());
                return; 
            }

            for (int i = start; i < elements.Length; i++)
            {
                comb[idx] = elements[i];
                GenerateCombinations(idx + 1, i + 1, elements, comb, combs);
            }
        }
    }
}