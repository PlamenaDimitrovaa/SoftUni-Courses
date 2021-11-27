using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> dict = new Dictionary<int, int>();
       
            for (int i = 0; i < n; i++)
            {
               int  num = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, 0);
                }     
                
                    dict[num]++;              
            }

            int number = dict.FirstOrDefault(x => x.Value % 2 == 0).Key;
            Console.WriteLine(number);
         
        }
    }
}
