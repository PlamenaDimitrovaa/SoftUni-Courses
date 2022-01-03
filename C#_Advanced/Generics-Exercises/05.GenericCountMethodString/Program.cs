using System;

namespace _05.GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);
            }

            string itemToCompare = Console.ReadLine();
            int result = box.CountGreaterThan(itemToCompare);
            Console.WriteLine(result);
        }
    }
}
