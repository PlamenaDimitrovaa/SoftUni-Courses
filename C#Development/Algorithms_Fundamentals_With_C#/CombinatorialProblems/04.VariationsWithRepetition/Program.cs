﻿using System;

namespace _04.VariationsWithRepetition
{
    public class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] variations;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());

            variations = new string[k];

            Variations(0);
        }

        private static void Variations(int idx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[idx] = elements[i];
                Variations(idx + 1);
            }
        }
    }
}