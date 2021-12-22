using System;
using System.Collections.Generic;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int row = 0;
            int col = 0;
            int food = 0;

            for (int rows = 0; rows < n; rows++)
            {
                string input = Console.ReadLine();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = input[cols];

                    if (matrix[rows, cols] == 'S')
                    {
                        row = rows;
                        col = cols;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    matrix[row, col] = '-';
                    row = row - 1; 
                    if (IsPositionValid(row, col, n, n)) 
                    {
                        SnakeMoves(n, matrix, ref row, ref col, ref food);
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {food}");
                        break;
                    }
                }
                else if (command == "down")
                {
                    matrix[row, col] = '-'; 
                    row = row + 1; 
                    if (IsPositionValid(row, col, n, n)) 
                    {
                        SnakeMoves(n, matrix, ref row, ref col, ref food);
                    }
                    else 
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {food}");
                        break;
                    }
                }
                else if (command == "left")
                {
                    matrix[row, col] = '-';
                    col = col - 1; 
                    if (IsPositionValid(row, col, n, n)) 
                    {
                        SnakeMoves(n, matrix, ref row, ref col, ref food);
                    }
                    else 
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {food}");
                        break;
                    }
                }
                else if (command == "right")
                {
                    matrix[row, col] = '-';
                    col = col + 1; 
                    if (IsPositionValid(row, col, n, n))
                    {
                        SnakeMoves(n, matrix, ref row, ref col, ref food);
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {food}");
                        break;
                    }
                }

                if (food >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    Console.WriteLine($"Money: {food}");
                    matrix[row, col] = 'S';
                    break;
                }

            }

            PrintMatrix(n, matrix);
        }

        private static void SnakeMoves(int n, char[,] matrix, ref int row, ref int col, ref int food)
        {
            if (char.IsDigit(matrix[row, col]))
            {
                food += int.Parse(matrix[row, col].ToString());
            }
            else if (matrix[row, col] == 'O') 
            {
                matrix[row, col] = '-';
                for (int rows = 0; rows < n; rows++)
                {
                    for (int cols = 0; cols < n; cols++)
                    {
                        if (matrix[rows, cols] == 'O')
                        {
                            matrix[rows, cols] = '-';
                            row = rows;
                            col = cols;
                        }
                    }
                }
            }
        }

        public static void PrintMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                return true;
            }
            else
            {
                return false;
            }
    
        }
    }
}
