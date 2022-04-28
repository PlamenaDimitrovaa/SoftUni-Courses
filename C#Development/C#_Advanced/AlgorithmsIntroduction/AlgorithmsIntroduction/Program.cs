using System;
using System.Linq;

namespace AlgorithmsIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(Sum(inputArray, 0));  
        }

        private static int Sum(int[] array, int currentIndex)
        {
            if (currentIndex == array.Length)
            {
                return 0;
            }

            return array[currentIndex] + Sum(array, currentIndex + 1);

        }
    }
}
