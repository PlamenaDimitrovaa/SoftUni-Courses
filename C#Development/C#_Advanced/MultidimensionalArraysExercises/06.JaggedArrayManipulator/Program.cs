using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                double[] inputIntegers = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jaggedArray[i] = inputIntegers;
            
            }
            for (int i = 0; i < jaggedArray.Length -1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i +1].Length)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] *= 2;
                        jaggedArray[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] /= 2;
                    }
                    for (int j = 0; j < jaggedArray[i +1].Length; j++)
                    {
                        jaggedArray[i + 1][j] /= 2;
                    }


                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArguments = command.Split();
                string action = commandArguments[0];
                int row = int.Parse(commandArguments[1]);
                int col = int.Parse(commandArguments[2]);
                int value = int.Parse(commandArguments[3]);

                if (!(row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length))
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (action == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else
                {
                    jaggedArray[row][col] -= value;
                }
                command = Console.ReadLine();
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }

        }
    }
}
