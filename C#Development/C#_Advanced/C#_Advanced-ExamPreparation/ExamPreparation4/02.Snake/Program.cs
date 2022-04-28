using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int snakeRow = 0;
            int snakeCol = 0;
            int foodQuantity = 0;
            int firstBurrowRow = 0;
            int firstBurrowCol = 0;
            int secondBurrowRow = 0;
            int secondBurrowCol = 0;

            for (int row = 0; row < n; row++)
            {
                var matrixRow = Console.ReadLine();
                for (int col = 0; col < matrixRow.Length; col++)
                {
                    matrix[row, col] = matrixRow[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (matrix[row, col] == 'B')
                    {
                        if (firstBurrowRow == 0)
                        {
                            firstBurrowRow = row;
                            firstBurrowCol = col;
                        }
                        else
                        {
                            secondBurrowRow = row;
                            secondBurrowCol = col;
                        }
                    }
                }
            }

            matrix[snakeRow, snakeCol] = '.';

            while (true)
            {
                if (foodQuantity >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    matrix[snakeRow, snakeCol] = 'S';
                    break;
                }

                string movement = Console.ReadLine();

                if (movement == "up")
                {
                    snakeRow--;
                }
                if (movement == "down")
                {
                    snakeRow++;
                }
                if (movement == "left")
                {
                    snakeCol--;
                }
                if (movement == "right")
                {
                    snakeCol++;
                }

                if (!(IsPositionValid(matrix, snakeRow, snakeCol)))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                }
                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';

                    if (firstBurrowRow == snakeRow && firstBurrowCol == snakeCol)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol = secondBurrowCol;
                    }
                    else
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;
                    }
                }

                matrix[snakeRow, snakeCol] = '.';
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");
            Print(matrix);
        }

        public static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
        static bool IsPositionValid(char[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
