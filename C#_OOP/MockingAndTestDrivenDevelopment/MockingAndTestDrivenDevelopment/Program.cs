using System;

namespace MockingAndTestDrivenDevelopment
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new GreetingWriter(new PrettyConsoleWriter());
            writer.WriteGreeting();
        }
    }
}
