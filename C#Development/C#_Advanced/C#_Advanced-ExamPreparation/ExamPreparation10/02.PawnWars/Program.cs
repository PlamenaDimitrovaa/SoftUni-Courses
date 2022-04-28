using System;

namespace _02.PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new char[8, 8];

            var whiteRow = 0;
            var whiteCol = 0;
            var blackRow = 0;
            var blackCol = 0;
            var whiteWins = false;
            var blackWins = false;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                var currRow = Console.ReadLine().ToCharArray();

                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    matrix[row, col] = currRow[col];

                    if (matrix[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (matrix[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            var boardWhiteRow = whiteRow + 1;
            var boardBlackRow = blackRow + 1;

            while (true)
            {
                if (CheckIfWhitePawnIsNear(whiteRow, whiteCol, blackRow, blackCol))
                {
                    char colInChar = ReturnChar(blackCol);
                    Console.WriteLine($"Game over! White capture on {colInChar}{boardBlackRow}.");
                    return;
                }

                whiteRow++;
                boardWhiteRow = whiteRow + 1;

                if (CheckIfBlackPawnIsNear(whiteRow, whiteCol, blackRow, blackCol))
                {
                    char colInChar = ReturnChar(whiteCol);
                    Console.WriteLine($"Game over! Black capture on {colInChar}{boardWhiteRow}.");
                    return;
                }

                blackRow--;
                boardBlackRow = blackRow + 1;

                if (whiteRow == 7)
                {
                    whiteWins = true;
                    break;
                }
                else if (blackRow == 1)
                {
                    blackWins = true;
                    break;
                }
            }

            if (whiteWins)
            {
                var letter = ReturnChar(whiteCol);
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {letter}8.");
            }
            else
            {
                var letter = ReturnChar(blackCol);
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {letter}1.");
            }
        }
        private static char ReturnChar(int number)
        {
            switch (number)
            {
                case 0: return 'a';
                case 1: return 'b';
                case 2: return 'c';
                case 3: return 'd';
                case 4: return 'e';
                case 5: return 'f';
                case 6: return 'g';
                default: return 'h';
            }
        }
        private static bool CheckIfWhitePawnIsNear(int whiteRow, int whiteCol, int blackRow, int blackCol)
        {
            if (blackRow - 1 == whiteRow && blackCol - 1 == whiteCol)
            {
                return true;
            }
            else if (blackRow - 1 == whiteRow && blackCol + 1 == whiteCol)
            {
                return true;
            }

            return false;
        }

        private static bool CheckIfBlackPawnIsNear(int whiteRow, int whiteCol, int blackRow, int blackCol)
        {
            if (whiteRow + 1 == blackRow && blackCol == whiteCol - 1)
            {
                return true;
            }
            else if (whiteRow + 1 == blackRow && blackCol == whiteCol + 1)
            {
                return true;
            }

            return false;
        }
    }
}

