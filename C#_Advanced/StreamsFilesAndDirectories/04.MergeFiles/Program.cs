using System;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
          
            string[] fileContent = File.ReadAllLines("Input1.txt");
            string[] fileContent1 = File.ReadAllLines("Input2.txt");
            File.WriteAllLines("result.txt", fileContent);
            foreach (var item in fileContent1)
            {
                File.AppendAllText("result.txt", $"{item} \n");
            }

        }
    }
}
