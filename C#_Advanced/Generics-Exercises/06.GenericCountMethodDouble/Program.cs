using System;

namespace _06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            var box = new Box<double>();
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Add(input);
            }

            double itemToCompare = double.Parse(Console.ReadLine());
            double result = box.CountGreaterThan(itemToCompare);
            Console.WriteLine(result);
        }
    }
}
