using System;

namespace _01.ClassBoxData
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            Box box = null;
            try
            {
                box = new Box(length, width, height);

            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
                return;
            }
            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.Volume():f2}");
        }
    }
}
