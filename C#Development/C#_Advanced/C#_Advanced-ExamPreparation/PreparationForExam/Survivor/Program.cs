using System;

namespace Guild
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] field = new string[rows][];

            var myTokens = 0;
            var enemyTokens = 0;

            for (int row = 0; row < rows; row++)
            {
                field[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];

                if (command == "Gong")
                {
                    break;
                }

                if (command == "Find")
                {
                    var row = int.Parse(input[1]);
                    var col = int.Parse(input[2]);
                    if (isPositionValid(field, row, col))
                    {
                        if (field[row][col] == "T")
                        {
                            myTokens++;
                            field[row][col] = "-";
                        }
                    }
                }
                else if (command == "Opponent")
                {
                    var row = int.Parse(input[1]);
                    var col = int.Parse(input[2]);
                    var direction = input[3];
                    if (isPositionValid(field, row, col))
                    {
                        if (field[row][col] == "T")
                        {
                            enemyTokens++;
                            field[row][col] = "-";
                            for (int i = 1; i <= 3; i++)
                            {
                                if (direction == "up")
                                {
                                    if (isPositionValid(field, row - i, col))
                                    {
                                        if (field[row - i][col] == "T")
                                        {
                                            enemyTokens++;
                                            field[row - i][col] = "-";
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (direction == "down")
                                {
                                    if (isPositionValid(field, row + i, col))
                                    {
                                        if (field[row + i][col] == "T")
                                        {
                                            enemyTokens++;
                                            field[row + i][col] = "-";
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (direction == "left")
                                {
                                    if (isPositionValid(field, row, col - i))
                                    {
                                        if (field[row][col - i] == "T")
                                        {
                                            enemyTokens++;
                                            field[row][col - i] = "-";
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else if (direction == "right")
                                {
                                    if (isPositionValid(field, row, col + i))
                                    {
                                        if (field[row][col + i] == "T")
                                        {
                                            enemyTokens++;
                                            field[row][col + i] = "-";
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {enemyTokens}");

            static bool isPositionValid(string[][] field, int row, int col)
            {
                return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field[row].Length;
            }
        }
    }
}

