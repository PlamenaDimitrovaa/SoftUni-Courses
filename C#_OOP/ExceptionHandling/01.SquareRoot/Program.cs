using System;

namespace _01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            static int Sqrt(double value)
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid number");
                }

                return (int)Math.Sqrt(value);
            }
            try
            {
                double n = double.Parse(Console.ReadLine());
                Sqrt(n);
                Console.WriteLine(Sqrt(n));
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
