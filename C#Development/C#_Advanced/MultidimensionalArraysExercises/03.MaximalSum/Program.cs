using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];
            int[,] matrix = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                int[] elements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            long maxSum = long.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int i = 0; i < matrix.GetLength(0) -2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-2; j++)
                {
                    var sum =
                          matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] 
                        + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] 
                        + matrix[i +2,j] + matrix[i + 2, j+1] + matrix[i+2,j+2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxRow; i <= maxRow + 2; i++)
            {
                for (int j = maxCol; j <= maxCol + 2; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}

