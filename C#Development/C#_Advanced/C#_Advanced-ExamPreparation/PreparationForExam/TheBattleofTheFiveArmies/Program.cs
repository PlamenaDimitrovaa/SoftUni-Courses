using System;

namespace TheBattleofTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] map = new char[rows][];
            var armyRow = -1;
            var armyCol = -1;

            for (int row = 0; row < rows; row++)
            {
                map[row] = Console.ReadLine().ToCharArray();
                for (int col = 0; col < map[row].Length; col++)
                {
                    if (map[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var movement = input[0];
                var row = int.Parse(input[1]);
                var col = int.Parse(input[2]);

                armor--;
                map[row][col] = 'O';
                map[armyRow][armyCol] = '-';
                if (movement == "up")
                {
                    if (IsPositionValid(map, armyRow - 1, armyCol))
                    {
                        armyRow--;
                    }
                }
                else if (movement == "down")
                {
                    if (IsPositionValid(map, armyRow + 1, armyCol))
                    {
                        armyRow++;
                    }
                }
                else if (movement == "left")
                {
                    if (IsPositionValid(map, armyRow, armyCol - 1))
                    {
                        armyCol--;
                    }
                }
                else if (movement == "right")
                {
                    if (IsPositionValid(map, armyRow, armyCol + 1))
                    {
                        armyCol++;
                    }
                }

                if (map[armyRow][armyCol] == 'O')
                {
                    armor -= 2;
                }

                if (map[armyRow][armyCol] == 'M')
                {
                    map[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                if (armor <= 0)
                {
                    map[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }
                map[armyRow][armyCol] = 'A';
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < map[row].Length; col++)
                {
                    Console.Write(map[row][col]);
                }
                Console.WriteLine();
            }

            static bool IsPositionValid(char[][] map, int row, int col)
            {
                return row >= 0 && row < map.GetLength(0) && col >= 0 && col < map[row].Length;
            }
        }
    }
}
