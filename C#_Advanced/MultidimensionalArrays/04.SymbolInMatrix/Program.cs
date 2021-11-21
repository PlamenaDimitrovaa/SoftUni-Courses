using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("");

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];

                }
            }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    string symbol = Console.ReadLine();
                    foreach (var item in matrix)
                    {
                        if (item == symbol)
                        {
                            Console.WriteLine($"({i}), ({j})");
                        }
                        else
                        {
                            Console.WriteLine($"{symbol} does not occur in the matrix");
                        }
                    }

                }
            }

        }
    }
}
