﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine().ToList();

            for (int i = 0; i < str.Count - 1; i++)
            {
                char curr = str[i];
                char next = str[i + 1];
                if (curr == next)
                {
                    str.RemoveAt(i);                 
                    i--;
                }
            }

            Console.WriteLine(string.Join("", str));
        }
    }
}
