using System;
using System.Linq;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputInfo = Console.ReadLine().Split();
            string firstName = inputInfo[0];
            string lastName = inputInfo[1];
            string address = inputInfo[2];
            string town = string.Join(" ", inputInfo.Skip(3));

            Threeuple<string, string, string> nameTown = new Threeuple<string, string, string>($"{firstName} {lastName}", $"{address}", town);

            inputInfo = Console.ReadLine().Split();
            string name = inputInfo[0];
            int litters = int.Parse(inputInfo[1]);
            bool isDrunk = inputInfo[2] == "drunk";

            Threeuple<string, int, bool> nameBeer = new Threeuple<string, int, bool>(name, litters, isDrunk);

            inputInfo = Console.ReadLine().Split();
            string numberName = inputInfo[0];
            double num2 = double.Parse(inputInfo[1]);
            string bankName = inputInfo[2];

            Threeuple<string, double, string> numbers = new Threeuple<string, double, string>(numberName, num2, bankName);

            Console.WriteLine(nameTown.GetItems());
            Console.WriteLine(nameBeer.GetItems());
            Console.WriteLine(numbers.GetItems());

        }
    }
}
