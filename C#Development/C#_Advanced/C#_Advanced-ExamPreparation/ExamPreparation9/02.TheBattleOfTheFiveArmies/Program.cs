using System;

namespace _02.TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            var armor = int.Parse(Console.ReadLine());
            var rows = int.Parse(Console.ReadLine());
            char[][] field = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                var chars = Console.ReadLine().ToCharArray();
                field[row] = chars;
            }

            var heroRow = 0;
            var heroCol = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'A')
                    {
                        heroRow = i;
                        heroCol = j;
                    }
                }
            }

            while (true)
            {
                var commandInfo = Console.ReadLine().Split();
                var direction = commandInfo[0];
                var orcRow = int.Parse(commandInfo[1]);
                var orcCol = int.Parse(commandInfo[2]);
                armor--;
                field[orcRow][orcCol] = 'O';
                field[heroRow][heroCol] = '-';

                if (direction == "up" && heroRow - 1 >= 0)
                {
                    heroRow--;
                }
                else if (direction == "down" && heroRow + 1 < rows)
                {
                    heroRow++;
                }
                else if (direction == "left" && heroCol - 1 >= 0)
                {
                    heroCol--;
                }
                else if (direction == "right" && heroCol + 1 < rows)
                {
                    heroCol++;
                }

                if (field[heroRow][heroCol] == 'O')
                {
                    armor -= 2;
                }

                if (field[heroRow][heroCol] == 'M')
                {
                    field[heroRow][heroCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                if (armor <= 0)
                {
                    field[heroRow][heroCol] = 'X';
                    Console.WriteLine($"The army was defeated at {heroRow};{heroCol}.");
                    break;
                }

                field[heroRow][heroCol] = 'A';
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    Console.Write(field[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}
