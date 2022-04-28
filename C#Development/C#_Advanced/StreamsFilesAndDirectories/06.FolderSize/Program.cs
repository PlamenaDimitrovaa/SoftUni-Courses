using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Users\User\source\repos\StreamsFilesAndDirectories\06.FolderSize\bin\Debug\netcoreapp3.1";
            string[] files = Directory.GetFiles(directoryPath);
            long totalLength = 0;
            foreach (var file in files)
            {
                totalLength += new FileInfo(file).Length;             
            }

            Console.WriteLine(totalLength);
        }
    }
}
