using System;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSizes = int.Parse(Console.ReadLine());
            int[] attackCommands = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] squareMatrix = new char[matrixSizes, matrixSizes];
            int playerOneShips = 0;
            int playerTwoShips = 0;
            int sumAllShips;

            for (int rowIndex = 0; rowIndex < squareMatrix.GetLength(0); rowIndex++)
            {
                char[] inputChar = Console.ReadLine()?.Replace(" ", "").ToCharArray();

                for (int colIndex = 0; colIndex < squareMatrix.GetLength(1); colIndex++)
                {
                    squareMatrix[rowIndex, colIndex] = inputChar[colIndex];
                    if (squareMatrix[rowIndex, colIndex] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (squareMatrix[rowIndex, colIndex] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }

            sumAllShips = playerOneShips + playerTwoShips;

            bool isFirstPlayerWon = false;
            bool isSecondPlayerWon = false;

            for (int i = 0; i < attackCommands.Length; i += 2)
            {
                int currentRow = attackCommands[i];
                int currentCol = attackCommands[i + 1];
                if (ValidateIndexes(squareMatrix, currentRow, currentCol))
                {
                    if (squareMatrix[currentRow, currentCol] == '>')
                    {
                        playerTwoShips -= 1;
                        squareMatrix[currentRow, currentCol] = 'X';
                        if (playerTwoShips <= 0)
                        {
                            isFirstPlayerWon = true;
                            break;
                        }
                    }
                    else if (squareMatrix[currentRow, currentCol] == '<')
                    {
                        playerOneShips -= 1;
                        squareMatrix[currentRow, currentCol] = 'X';
                        if (playerOneShips <= 0)
                        {
                            isSecondPlayerWon = true;
                            break;
                        }
                    }
                    else if (squareMatrix[currentRow, currentCol] == '#')
                    {
                        ValidateMineCoordinates(squareMatrix, currentRow, currentCol);
                        int[] shipsCount = CheckShips(squareMatrix);
                        playerOneShips = shipsCount[0];
                        playerTwoShips = shipsCount[1];

                        if (playerOneShips <= 0)
                        {
                            isSecondPlayerWon = true;
                            break;
                        }

                        if (playerTwoShips <= 0)
                        {
                            isFirstPlayerWon = true;
                            break;
                        }
                    }
                }
            }

            int defeatedShips = sumAllShips - (playerOneShips + playerTwoShips);
            if (isFirstPlayerWon)
            {
                Console.WriteLine($"Player One has won the game! {defeatedShips} ships have been sunk in the battle.");
            }
            else if (isSecondPlayerWon)
            {
                Console.WriteLine($"Player Two has won the game! {defeatedShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
        }

        public static bool ValidateIndexes(char[,] squareMatrix, int row, int col)
        {
            return row >= 0 && row < squareMatrix.GetLength(0) && col >= 0 && col < squareMatrix.GetLength(1);
        }

        public static void ValidateMineCoordinates(char[,] squareMatrix, int row, int col)
        {
            if (ValidateIndexes(squareMatrix, row - 1, col))
            {
                squareMatrix[row - 1, col] = 'X';
            }

            if (ValidateIndexes(squareMatrix, row + 1, col))
            {
                squareMatrix[row + 1, col] = 'X';
            }

            if (ValidateIndexes(squareMatrix, row, col - 1))
            {
                squareMatrix[row, col - 1] = 'X';
            }

            if (ValidateIndexes(squareMatrix, row, col + 1))
            {
                squareMatrix[row, col + 1] = 'X';
            }

            if (ValidateIndexes(squareMatrix, row + 1, col + 1))
            {
                squareMatrix[row + 1, col + 1] = 'X';
            }

            if (ValidateIndexes(squareMatrix, row + 1, col - 1))
            {
                squareMatrix[row + 1, col - 1] = 'X';
            }

            if (ValidateIndexes(squareMatrix, row - 1, col + 1))
            {
                squareMatrix[row - 1, col + 1] = 'X';
            }

            if (ValidateIndexes(squareMatrix, row - 1, col - 1))
            {
                squareMatrix[row - 1, col - 1] = 'X';
            }
        }

        public static int[] CheckShips(char[,] squareMatrix)
        {
            int[] shipsArray = new int[2];
            int playerOneShips = 0;
            int playerTwoShips = 0;

            for (int rowIndex = 0; rowIndex < squareMatrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < squareMatrix.GetLength(1); colIndex++)
                {
                    if (squareMatrix[rowIndex, colIndex] == '<')
                    {
                        playerOneShips++;
                    }

                    if (squareMatrix[rowIndex, colIndex] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }

            shipsArray[0] += playerOneShips;
            shipsArray[1] += playerTwoShips;

            return shipsArray;


        }
    }
}