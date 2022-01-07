using System;

namespace _02.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int factoriel = GetFactoriel(n);
            Console.WriteLine(factoriel);
        }

        private static int GetFactoriel(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * GetFactoriel(n - 1);
        }
    }
}
