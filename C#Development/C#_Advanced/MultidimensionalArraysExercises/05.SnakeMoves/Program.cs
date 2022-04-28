using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfMatrix = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = sizeOfMatrix[0];
            int cols = sizeOfMatrix[1];

            string snake = Console.ReadLine();
            char[,] matrix = new char[rows, cols];
            bool isLeftToRight = true;
            int counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (isLeftToRight)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snake[counter++];

                        if (counter == snake.Length)
                        {
                            counter = 0;

                        }
                    }

                    isLeftToRight = false;
                }
                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snake[counter++];

                        if (counter == snake.Length)
                        {
                            counter = 0;

                        }
                    }

                    isLeftToRight = true;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
