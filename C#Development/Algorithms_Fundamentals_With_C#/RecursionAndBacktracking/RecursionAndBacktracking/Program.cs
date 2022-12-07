using System;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main()
        {
            //1.Recursive Array Sum
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(GetSum(arr, 0));
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
