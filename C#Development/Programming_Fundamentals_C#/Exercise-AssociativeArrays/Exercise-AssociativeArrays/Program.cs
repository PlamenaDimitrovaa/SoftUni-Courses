using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise_AssociativeArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> first = Console.ReadLine().Split().ToList();
            if (first.Count > 1)

            {
                Merge(first);
            }

            char[] word = first[0].ToCharArray();

            Dictionary<char, int> numberChar = new Dictionary<char, int>();

            foreach (var kvp in word)

            {

                if (!numberChar.ContainsKey(kvp))

                {

                    numberChar[kvp] = 0;

                }



                numberChar[kvp]++;

            }

            foreach (var kvp in numberChar)

            {

                Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);

            }

        }

        public static void Merge(List<string> first)

        {

            StringBuilder currentWord = new StringBuilder();

            for (int i = 0; i < first.Count; i++)

            {

                currentWord.Append(first[i]);

            }

            first.RemoveRange(0, first.Count - 1);

            first.Insert(0, currentWord.ToString());

        }

    }

}
  
