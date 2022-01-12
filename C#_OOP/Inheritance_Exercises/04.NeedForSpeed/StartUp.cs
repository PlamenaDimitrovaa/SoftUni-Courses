using System;

namespace NeedForSpeed
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var vehicle = new Vehicle(100,10);
            vehicle.Drive(10);
        }
    }
}
