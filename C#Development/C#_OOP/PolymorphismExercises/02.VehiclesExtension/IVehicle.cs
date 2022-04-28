using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public bool CanDrive(double km);
        public bool IsEmpty { get; set; }
        void Drive(double km);
        void Refuel(double litters);
    }
}
