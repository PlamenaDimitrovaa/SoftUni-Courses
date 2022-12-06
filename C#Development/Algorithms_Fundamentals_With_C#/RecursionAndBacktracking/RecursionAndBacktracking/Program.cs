using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Recursive Array Sum
            int[] arr = { 1,2,3,4 };
            Console.WriteLine(GetSum(arr, 1));
        }

        //1.Recursive Array Sum
            private static int GetSum(int[] arr, int index)
            {
                if (index >= arr.Length)
                {
                    return 0;
                }

                return arr[index] + GetSum(arr, index + 1);
            }
    }
}
