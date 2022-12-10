using System;

namespace _07.RecursiveFibonacci
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(CalcFibonacci(n));
        }

        static long CalcFibonacci(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            return CalcFibonacci(number - 1) + CalcFibonacci(number - 2);
        }
    }
}