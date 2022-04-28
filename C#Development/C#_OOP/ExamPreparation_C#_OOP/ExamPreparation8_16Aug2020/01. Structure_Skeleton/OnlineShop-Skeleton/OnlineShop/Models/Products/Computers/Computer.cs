using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
          => this.components.Count <= 0
          ? base.OverallPerformance
          : base.OverallPerformance + this.components.Average(c => c.OverallPerformance);

        public override decimal Price
            => base.Price + this.components.Sum(c => c.Price) + this.peripherals.Sum(p => p.Price);

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {
            if (components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists " +
                   $"in {this.GetType().Name} with Id {this.Id}.");
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count <= 0 || !components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IComponent component = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count <= 0 || !peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IPeripheral peripheral = this.peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}" +
                           $": {this.Manufacturer} {this.Model} (Id: {this.Id})");

            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            sb.AppendLine($" Peripherals ({this.Peripherals.Count});" +
                $" Average Overall Performance ({(this.Peripherals.Count <= 0 ? 0 : this.Peripherals.Average(p => p.OverallPerformance)):f2}):");

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
