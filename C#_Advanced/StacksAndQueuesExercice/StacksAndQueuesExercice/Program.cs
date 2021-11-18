using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueuesExercice
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int secondsToPass = int.Parse(Console.ReadLine());

            Queue<string> carQueue = new Queue<string>();

            int totalCarsPassed = 0;

            while (true)
            {
                string cmd = Console.ReadLine();
                int greenLight = greenLightSeconds;
                int passSeconds = secondsToPass;

                if (cmd == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
                    return;
                }

                if (cmd == "green")
                {
                    while (greenLight > 0 && carQueue.Count != 0)
                    {
                        string firstInQueue = carQueue.Dequeue();
                        greenLight -= firstInQueue.Length;
                        if (greenLight > 0)
                        {
                            totalCarsPassed++;
                        }
                        else
                        {
                            passSeconds += greenLight;
                            if (passSeconds < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{firstInQueue} was hit at {firstInQueue[firstInQueue.Length + passSeconds]}.");
                                return;
                            }

                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    carQueue.Enqueue(cmd);
                }
            }
        }
    }
}
