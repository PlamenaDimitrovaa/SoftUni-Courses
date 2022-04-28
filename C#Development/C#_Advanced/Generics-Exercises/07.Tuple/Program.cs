using System;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {

            var inputInfo = Console.ReadLine().Split();
            string firstName = inputInfo[0];
            string lastName = inputInfo[1];
            string address = inputInfo[2];

            Tuple<string, string> nameTown = new Tuple<string, string>($"{firstName} {lastName}", $"{address}");

            inputInfo = Console.ReadLine().Split();
            string name = inputInfo[0];
            int litters = int.Parse(inputInfo[1]);

            Tuple<string, int> nameBeer = new Tuple<string, int>(name, litters);

            inputInfo = Console.ReadLine().Split();
            int num = int.Parse(inputInfo[0]);
            double num2 = double.Parse(inputInfo[1]);

            Tuple<int, double> numbers = new Tuple<int, double>(num, num2);

            Console.WriteLine(nameTown.GetItems());
            Console.WriteLine(nameBeer.GetItems());
            Console.WriteLine(numbers.GetItems());


        }
    }
}
