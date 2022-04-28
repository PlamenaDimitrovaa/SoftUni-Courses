using System;

namespace Generics_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                box.Add(line);
            }

            Console.WriteLine(box);
        }
    }
}
