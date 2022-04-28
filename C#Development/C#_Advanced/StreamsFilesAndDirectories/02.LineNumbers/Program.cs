using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader("countries.txt");
            using StreamWriter sw = new StreamWriter("countriesWithLineNumber.txt");
            int rowNum = 1;
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                sw.WriteLine($"{rowNum}. {line}");
                rowNum++;
            }

        }
    }
}
