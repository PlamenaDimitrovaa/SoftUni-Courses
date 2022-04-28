using System;
using System.Collections.Generic;
using System.Text;

namespace MockingAndTestDrivenDevelopment
{
    public class PrettyConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"- {text}                                             -");
            Console.WriteLine(new string('-', 60));
        }
    }
}
