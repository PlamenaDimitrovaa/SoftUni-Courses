using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int durationOfGreen = int.Parse(Console.ReadLine());
            int durationOfFreeWindow = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int timeForPass = durationOfGreen + durationOfFreeWindow;
            int counter = 0;
            Queue<string> queue = new Queue<string>();

            while (command != "END")
            {
                if (command != "END" && command != "green")
                {
                    queue.Enqueue(command);
                }

                if (command == "green")
                {
                  
                    if (timeForPass > command.Length)
                    {
                        timeForPass -= command.Length;
                        queue.Dequeue();
                        counter++;
                    }
                    else
                    {

                    }
                }


                command = Console.ReadLine();
            }

        }
    }
}
