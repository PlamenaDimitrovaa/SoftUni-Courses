using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set => fuelQuantity = value;
        }
        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }

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
            this.FuelQuantity += litters;
        }
    }
}
