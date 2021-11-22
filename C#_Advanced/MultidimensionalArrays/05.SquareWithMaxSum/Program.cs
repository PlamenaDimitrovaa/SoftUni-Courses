using System;
using System.Linq;

namespace _05.SquareWithMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];
            int[,] matrix = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                int[] elements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            long maxSum = long.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    var sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            for (int i = maxRow; i < maxRow +2; i++)
            {
                for (int j = maxCol; j < maxCol + 2; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
