using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }
        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }
        public double TankCapacity
        {
            get => tankCapacity;
            set => tankCapacity = value;
        }
        public bool IsEmpty { get; set; }

        public bool CanDrive(double km)
        {
            if (this.FuelQuantity - (km * this.FuelConsumption) >= 0)
            {
                return true;
            }

            return false;
        }
        public void Drive(double km)
        {
            if (!CanDrive(km))
            {
                return;
            }

            this.FuelQuantity -= km * this.FuelConsumption;
        }

        public virtual void Refuel(double litters)
        {
            ValidateLiters(litters);
            ValidateQuantity(litters);

            this.FuelQuantity += litters;
        }

        protected void ValidateQuantity(double litters)
        {
            if (litters + this.FuelQuantity > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {litters} fuel in the tank");
            }
        }

        protected static void ValidateLiters(double litters)
        {
            if (litters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }
    }
}
