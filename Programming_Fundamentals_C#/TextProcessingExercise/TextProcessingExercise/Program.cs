using System;

namespace TextProcessingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                if (item.Length < 3 || item.Length > 16)
                {
                    continue;
                }

                bool isValid = false;

                foreach (var element in item)
                {
                    if (!(char.IsLetterOrDigit(element) || element == '-' || element == '_'))
                    {
                        isValid = false;
                        break;
                    }
                    isValid = true;
                }

                if (isValid)
                {
                    Console.WriteLine(item);
                }

            }
        }
    }
}
