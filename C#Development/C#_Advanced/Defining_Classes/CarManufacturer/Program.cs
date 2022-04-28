using System;

namespace CarManufacturer
{
    public class StartUp
    {

        public class Car
        {
            private string make;
            private string model;
            private int year;
            public string Make
            {
                get
                {
                    return make;
                }
                set
                {
                    make = value;
                }
            }
            public string Model
            {
                get
                {
                    return model;
                }
                set
                {
                    model = value;
                }
            }
            public int Year
            {
                get
                {
                    return year;
                }

                set
                {
                    year = value;
                }
            }

        }
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
