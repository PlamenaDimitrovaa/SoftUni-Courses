using System;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine().Split();
            var websites = Console.ReadLine().Split();
            Smartphone smartphone = new Smartphone();

            foreach (var number in phoneNumbers)
            {
                Console.WriteLine(smartphone.Calling(number));
            }

            foreach (var url in websites)
            {
                Console.WriteLine(smartphone.Browsing(url));
            }
        }
    }
}
