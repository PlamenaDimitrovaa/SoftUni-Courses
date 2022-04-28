using System;
using System.Linq;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];
            int[,] array = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                int[] elements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < col; j++)
                {
                    array[i, j] = elements[j];
                }
            
            }
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
               
            }

            Console.WriteLine(row);
            Console.WriteLine(col);
            Console.WriteLine(sum);
        }
    }
}
