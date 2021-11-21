using System;
using System.Linq;

namespace _02.SumMatrixColumn
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];
            int[,] array = new int[row, col];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int[] elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = elements[j];

                }
            }


            for (int i = 0; i < array.GetLength(1); i++)
            {
                int sum = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    sum += array[j, i];

                }
                Console.WriteLine(sum);
            }

        }
    }
}
