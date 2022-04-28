using System;
using System.Linq;

namespace _6.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] arrays = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                arrays[i] = new int[input.Length];

                for (int j = 0; j < input.Length; j++)
                {
                    arrays[i][j] = input[j];
                }
            }
            while (true)
            {
                var line = Console.ReadLine().Split();
                var commandName = line[0];
                if (commandName == "END")
                {
                    break;
                }

                var arrayIndex = int.Parse(line[1]);
                var arrayElement = int.Parse(line[2]);
                var value = int.Parse(line[3]);

                if (arrayIndex < 0 || arrayIndex >= arrays.Length || arrayElement < 0 || arrayElement >= arrays[arrayIndex].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (commandName == "Add")
                {
                    arrays[arrayIndex][arrayElement] += value;
                }
                else if (commandName == "Subtract")
                {
                    arrays[arrayIndex][arrayElement] -= value;
                }
            }

            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    Console.Write(arrays[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
