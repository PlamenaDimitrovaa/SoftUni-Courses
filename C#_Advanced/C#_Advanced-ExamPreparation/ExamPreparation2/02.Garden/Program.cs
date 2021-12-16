using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int isRow = dimension[0];
            int isCol = dimension[1];
            int[,] garden = new int[isRow, isCol];
            for (int i = 0; i < isRow; i++)
            {
                for (int j = 0; j < isCol; j++)
                {
                    garden[i, j] = 0;                  
                }
            }

           
            while (true)
            {
                var position = Console.ReadLine();
                if (position == "Bloom Bloom Plow")
                {
                    break;
                }            
                var positionInfo = position.Split();
                var row = int.Parse(positionInfo[0]);
                var col = int.Parse(positionInfo[1]);

                if (row < 0 || row > garden.GetLength(0) && col < 0 || col > garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int i = 0; i < garden.GetLength(0); i++)
                {
                    garden[row, i]++;
                }
                for (int j   = 0; j < garden.GetLength(1); j++)
                {
                    garden[j, col]++;
                }
                garden[row, col]--;
            }

            for (int i = 0; i < isRow; i++)
            {
                for (int j = 0; j < isCol; j++)
                {
                    Console.Write(garden[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
