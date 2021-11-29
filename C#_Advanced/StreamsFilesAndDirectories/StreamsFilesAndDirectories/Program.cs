using System;
using System.IO;

namespace StreamsFilesAndDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader("countries.txt");
            using StreamWriter sw = new StreamWriter("oddCountries.txt");
            int rowNum = 0;
        
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (rowNum % 2 == 1)
                {
                    sw.WriteLine(line);
                }

                rowNum++;
            }

        }
    }
}
