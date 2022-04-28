
using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int days = DateModifier.CalculateDifferenceInDays(firstDate, secondDate);
            Console.WriteLine(Math.Abs(days));
        }
    }
}
