using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] array = new int[n, n];
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    array[i, j] = input[j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        sum += array[i, j];
                }

            }
            Console.WriteLine(sum);
        }
    }
}
