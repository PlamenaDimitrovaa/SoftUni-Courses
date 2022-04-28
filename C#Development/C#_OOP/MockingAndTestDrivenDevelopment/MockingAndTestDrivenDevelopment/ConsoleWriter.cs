using System;
using System.Collections.Generic;
using System.Text;

namespace MockingAndTestDrivenDevelopment
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
