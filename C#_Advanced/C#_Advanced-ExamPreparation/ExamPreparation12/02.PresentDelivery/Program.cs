using System;
using System.Linq;

namespace _02.PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var presentCount = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            char[,] hood = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                var line = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < line.Length; col++)
                {
                    hood[row, col] = line[col];
                }
            }

            var santaRow = 0;
            var santaCol = 0;
            var niceKidsCounter = 0;

            for (int row = 0; row < hood.GetLength(0); row++)
            {
                for (int col = 0; col < hood.GetLength(1); col++)
                {
                    if (hood[row, col] == 'S')
                    {
                        santaRow = row;
                        santaCol = col;
                    }

                    if (hood[row, col] == 'V')
                    {
                        niceKidsCounter++;
                    }
                }
            }

            var command = Console.ReadLine();
            while (command != "Christmas morning")
            {
                if (presentCount <= 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    break;
                }

                hood[santaRow, santaCol] = '-';

                if (command == "up")
                {
                    santaRow--;
                }
                else if (command == "down")
                {
                    santaRow++;
                }
                else if (command == "left")
                {
                    santaCol--;
                }
                else if (command == "right")
                {
                    santaCol++;
                }

                if (hood[santaRow, santaCol] == 'V')
                {
                    presentCount--;
                }
                else if (hood[santaRow, santaCol] == 'C')
                {
                    if (hood[santaRow, santaCol - 1] != '-')
                    {
                        presentCount--;
                        hood[santaRow, santaCol - 1] = '-';
                    }
                    if (hood[santaRow, santaCol + 1] != '-')
                    {
                        presentCount--;
                        hood[santaRow, santaCol + 1] = '-';
                    }
                    if (hood[santaRow - 1, santaCol] != '-')
                    {
                        presentCount--;
                        hood[santaRow - 1, santaCol] = '-';
                    }
                    if (hood[santaRow + 1, santaCol] != '-')
                    {
                        presentCount--;
                        hood[santaRow + 1, santaCol] = '-';
                    }
                }
                command = Console.ReadLine();
            }

            hood[santaRow, santaCol] = 'S';
            var niceKidsWithoutPresent = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (hood[row, col] == 'V')
                    {
                        niceKidsWithoutPresent++;
                    }
                }
            }

            PrintMatrix(hood);

            if (niceKidsWithoutPresent == 0)
            {
                Console.WriteLine($"Good job, Santa! {niceKidsCounter} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKidsWithoutPresent} nice kid/s.");
            }


            static void PrintMatrix(char[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
