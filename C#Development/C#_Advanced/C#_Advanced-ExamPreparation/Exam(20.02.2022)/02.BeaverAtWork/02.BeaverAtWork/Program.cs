using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BeaverAtWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int beeverRow = 0;
            int beeverCol = 0;
            int branchesCount = 0;
            Stack<char> collectedBranchesStack = new Stack<char>();
            char[,] field = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = currentRow[col];
                    if (currentRow[col] == 'B')
                    {
                        beeverRow = row;
                        beeverCol = col;
                    }
                    else if (char.IsLower(currentRow[col]))
                    {
                        branchesCount++;
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                bool hasMoved = false;
                switch (command)
                {
                    case "up":
                        if (inRange(field, beeverRow - 1, beeverCol))
                        {
                            field[beeverRow, beeverCol] = '-';
                            hasMoved = true;
                            beeverRow--;
                        }
                        else
                        {
                            if (collectedBranchesStack.Count > 0)
                            {
                                collectedBranchesStack.Pop();
                            }
                        }
                        break;
                    case "down":
                        if (inRange(field, beeverRow + 1, beeverCol))
                        {
                            field[beeverRow, beeverCol] = '-';
                            hasMoved = true;
                            beeverRow++;
                        }
                        else
                        {
                            if (collectedBranchesStack.Count > 0)
                            {
                                collectedBranchesStack.Pop();
                            }

                        }
                        break;
                    case "right":
                        if (inRange(field, beeverRow, beeverCol + 1))
                        {
                            field[beeverRow, beeverCol] = '-';
                            hasMoved = true;
                            beeverCol++;
                        }
                        else
                        {
                            if (collectedBranchesStack.Count > 0)
                            {
                                collectedBranchesStack.Pop();
                            }

                        }
                        break;
                    case "left":
                        if (inRange(field, beeverRow, beeverCol - 1))
                        {
                            field[beeverRow, beeverCol] = '-';
                            hasMoved = true;
                            beeverCol--;
                        }
                        else
                        {
                            if (collectedBranchesStack.Count > 0)
                            {
                                collectedBranchesStack.Pop();
                            }

                        }
                        break;
                }
                if (field[beeverRow, beeverCol] == '-')
                {
                    field[beeverRow, beeverCol] = 'B';
                }
                else if (field[beeverRow, beeverCol] == 'F')
                {
                    field[beeverRow, beeverCol] = '-';
                    switch (command)
                    {
                        case "up":
                            if (beeverRow == 0)
                            {
                                beeverRow = field.GetLength(0) - 1;
                            }
                            else
                            {
                                beeverRow = 0;
                            }
                            break;
                        case "down":
                            if (beeverRow == field.GetLength(0) - 1)
                            {
                                beeverRow = 0;
                            }
                            else
                            {
                                beeverRow = field.GetLength(0) - 1;
                            }
                            break;
                        case "right":
                            if (beeverCol == field.GetLength(1) - 1)
                            {
                                beeverCol = 0;
                            }
                            else
                            {
                                beeverCol = field.GetLength(1) - 1;
                            }
                            break;
                        case "left":
                            if (beeverCol == 0)
                            {
                                beeverCol = field.GetLength(1) - 1;
                            }
                            else
                            {
                                beeverCol = 0;
                            }
                            break;
                    }
                    if (char.IsLower(field[beeverRow, beeverCol]))
                    {
                        collectedBranchesStack.Push(field[beeverRow, beeverCol]);
                        branchesCount--;
                    }
                    field[beeverRow, beeverCol] = 'B';
                }
                else if (char.IsLower(field[beeverRow, beeverCol]))
                {
                    collectedBranchesStack.Push(field[beeverRow, beeverCol]);
                    branchesCount--;
                    field[beeverRow, beeverCol] = 'B';
                }
                if (branchesCount == 0)
                {
                    Console.WriteLine($"The Beaver successfully collect {collectedBranchesStack.Count} wood branches: {string.Join(", ", collectedBranchesStack.Reverse())}.");
                    break;
                }
                command = Console.ReadLine();
            }
            if (branchesCount > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCount} branches left.");
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static bool inRange(char[,] matrix, int row, int col) => row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
    }
}