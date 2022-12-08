using System;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(CalcFactorielRecursively(n));
        }

        private static int CalcFactorielRecursively(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * CalcFactorielRecursively(n - 1);
        }
    }
}
