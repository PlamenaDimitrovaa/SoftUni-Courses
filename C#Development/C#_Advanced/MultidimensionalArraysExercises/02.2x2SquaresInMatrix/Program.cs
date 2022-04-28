using System;
using System.Linq;

namespace _02._2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];
            string[,] matrix = new string[row, col];

            for (int i = 0; i < row; i++)
            {
                string[] elements = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < col; j++)
                {
                    matrix[i,j] = elements[j];
                }
            }

            int count = 0;
         

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i,j] == matrix[i,j + 1]
                        && matrix[i,j] == matrix[i+ 1,j] 
                        && matrix[i,j] == matrix[i + 1, j+ 1])
                    {
                        count++;
                    }               
                }
            }

            Console.WriteLine(count);
        }
    }
}
