using System;

namespace _05.CombinationsWithoutRepetition
{
    public class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] combinations;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            combinations = new string[k];

            Combinations(0, 0);
        }

        private static void Combinations(int idx, int elementsStartIdx)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIdx; i < elements.Length; i++)
            {
                combinations[idx] = elements[i];
                Combinations(idx + 1, i + 1);
            }
        }
    }
}