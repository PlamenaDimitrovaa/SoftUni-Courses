using System;
using System.Linq;

namespace FunctionalProgrammingExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in input)
            {
                Action<string> print = item => Console.WriteLine(item);
                print(item);

            }
        }
        static void Method(string item)
        {
            Console.WriteLine(item);
        }
    }
}
