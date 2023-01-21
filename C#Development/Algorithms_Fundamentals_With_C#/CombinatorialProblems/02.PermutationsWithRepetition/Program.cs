using System;
using System.Collections.Generic;

namespace _02.PermutationsWithRepetition
{
    public class Program
    {
        private static string[] elements;
        public static void Main()
        {
            elements = Console.ReadLine().Split();

            PermutationsWithRepetition(0);
        }

        private static void PermutationsWithRepetition(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));

                return;
            }

            PermutationsWithRepetition(index + 1);

            var used = new HashSet<string> { elements[index] };

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    Swap(index, i);
                    PermutationsWithRepetition(index + 1);
                    Swap(index, i);

                    used.Add(elements[i]);
                }
            }
        }
        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}

//public class Program
//{
//    private static string[] elements;
//    private static List<string> results;
//    public static void Main()
//    {
//        elements = Console.ReadLine().Split();

//        results = new List<string>();
//        PermutationsWithRepetition(0);
//        Console.WriteLine($"Permutations with repetition: {results.Count}");

//        results = new List<string>();
//        PermutationsWithoutRepetition(0);
//        Console.WriteLine($"Permutations without repetition: {results.Count}");
//    }

//    private static void PermutationsWithRepetition(int index)
//    {
//        if (index >= elements.Length)
//        {
//            results.Add(string.Join(" ", elements));

//            return;
//        }

//        PermutationsWithRepetition(index + 1);

//        var used = new HashSet<string> { elements[index] };

//        for (int i = index + 1; i < elements.Length; i++)
//        {
//            if (!used.Contains(elements[i]))
//            {
//                Swap(index, i);
//                PermutationsWithRepetition(index + 1);
//                Swap(index, i);

//                used.Add(elements[i]);
//            }
//        }
//    }

//    private static void PermutationsWithoutRepetition(int index)
//    {
//        if (index >= elements.Length)
//        {
//            results.Add(string.Join(" ", elements));

//            return;
//        }

//        PermutationsWithoutRepetition(index + 1);

//        for (int i = index + 1; i < elements.Length; i++)
//        {
//            Swap(index, i);
//            PermutationsWithoutRepetition(index + 1);
//            Swap(index, i);
//        }
//    }

//    private static void Swap(int first, int second)
//    {
//        var temp = elements[first];
//        elements[first] = elements[second];
//        elements[second] = temp;
//    }
//}