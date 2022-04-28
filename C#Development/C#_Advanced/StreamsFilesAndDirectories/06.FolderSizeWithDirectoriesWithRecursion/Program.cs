using System;
using System.IO;

namespace _06.FolderSizeWithDirectoriesWithRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Users\User\source\repos\StreamsFilesAndDirectories\06.FolderSize\bin\Debug\netcoreapp3.1";
            var totalLength = GetTotalLength(directoryPath);
            Console.WriteLine(totalLength);

        }
        static long GetTotalLength(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            long totalLength = 0;
            foreach (var file in files)
            {
                totalLength += new FileInfo(file).Length;
            }

            return totalLength;
        }
    }
}
