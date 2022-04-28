using System;
using System.Linq;

namespace MultidimensionalArraysExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] arrays = new int[n, n];

            for (int i = 0; i < arrays.GetLength(0); i++)
            {
                int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < arrays.GetLength(1); j++)
                {
                    arrays[i, j] = elements[j];
                }
            }
            int primaryDiagonal = 0;
            int secondDiagonal = 0;

            for (int i = 0; i < arrays.GetLength(0); i++)
            {
                primaryDiagonal += arrays[i, i];
                secondDiagonal += arrays[i, n - i - 1];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondDiagonal));
        }
    }
}
