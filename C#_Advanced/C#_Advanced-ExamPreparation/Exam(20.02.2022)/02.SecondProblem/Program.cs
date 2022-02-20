using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SecondProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] pond = new char[n, n];
            var branches = new Stack<char>();
            var totalBranches = 0;
            var beaverRow = -1;
            var beaverCol = -1;
            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < line.Length; col++)
                {
                    pond[row, col] = line[col];

                    if (pond[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }

                    if (char.IsLower(pond[row, col]))
                    {
                        totalBranches++;
                    }
                }
            }

            var command = Console.ReadLine();
            while (command != "end")
            {
                pond[beaverRow, beaverCol] = '-';
                if (command == "up")
                {
                    if (IsPositionValid(pond, beaverRow - 1, beaverCol))
                    {
                        beaverRow = MoveRow(beaverRow, command);
                    }
                    else
                    {
                        if (branches.Any())
                        {
                            branches.Pop();
                        }
                    }
                }
                else if (command == "down")
                {
                    if (IsPositionValid(pond, beaverRow + 1, beaverCol))
                    {
                        beaverRow = MoveRow(beaverRow, command);
                    }
                    else
                    {
                        if (branches.Any())
                        {
                            branches.Pop();
                        }
                    }
                }
                else if (command == "left")
                {
                    if (IsPositionValid(pond, beaverRow, beaverCol - 1))
                    {
                        beaverCol = MoveCol(beaverCol, command);
                    }
                    else
                    {
                        if (branches.Any())
                        {
                            branches.Pop();
                        }
                    }
                }
                else if (command == "right")
                {
                    if (IsPositionValid(pond, beaverRow, beaverCol + 1))
                    {
                        beaverCol = MoveCol(beaverCol, command);

                    }
                    else
                    {
                        if (branches.Any())
                        {
                            branches.Pop();
                        }
                    }
                }

                if (char.IsLower(pond[beaverRow, beaverCol]))
                {
                    branches.Push(pond[beaverRow, beaverCol]);
                }
                if (pond[beaverRow, beaverCol] == 'F')
                {
                    if (command == "up" && beaverRow == 0)
                    {
                        command = "down";
                    }
                    else if (command == "down" && beaverRow == pond.GetLength(0))
                    {
                        command = "up";
                    }
                    else if (command == "left" && beaverCol == 0)
                    {
                        command = "right";
                    }
                    else if (command == "right" && beaverCol == pond.GetLength(1))
                    {
                        command = "left";
                    }
                    while (true)
                    {
                        var lastRow = beaverRow;
                        var lastCol = beaverCol;
                        if (command == "up" || command == "down")
                        {
                            beaverRow = MoveRow(beaverRow, command);
                        }
                        else if (command == "left" || command == "right")
                        {
                            beaverCol = MoveCol(beaverCol, command);
                        }
                        if (char.IsLower(pond[beaverRow, beaverCol]))
                        {
                            branches.Push(pond[beaverRow, beaverCol]);
                        }
                        if (lastRow == beaverRow && lastCol == beaverCol)
                        {
                            break;
                        }

                        pond[beaverRow, beaverCol] = '-';
                    }
                }

                pond[beaverRow, beaverCol] = 'B';
                command = Console.ReadLine();
            }

            if (totalBranches == branches.Count())
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count()} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranches - branches.Count()} branches left.");
            }
            Print(pond);

            static void Print(char[,] matrix)
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

            static int MoveRow(int row, string movement)
            {
                if (movement == "up")
                {
                    return row - 1;
                }
                if (movement == "down")
                {
                    return row + 1;
                }
                return row;
            }

            static int MoveCol(int col, string movement)
            {
                if (movement == "left")
                {
                    return col - 1;
                }
                if (movement == "right")
                {
                    return col + 1;
                }

                return col;
            }
        }
    }
}
