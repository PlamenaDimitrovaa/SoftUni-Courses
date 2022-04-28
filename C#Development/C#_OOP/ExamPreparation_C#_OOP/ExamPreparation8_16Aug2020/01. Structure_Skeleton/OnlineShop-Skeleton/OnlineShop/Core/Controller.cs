using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using IComponent = OnlineShop.Models.Products.Components.IComponent;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        public Controller()
        {
            computers = new List<IComputer>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComponent component = null;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            if (computer.Components.Any(x => x.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            computer.AddComponent(component);
            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = null;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            computers.Add(computer);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IPeripheral peripheral = null;

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            if (computer.Peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            computer.AddPeripheral(peripheral);
            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            IComputer toRemove = computers.Where(x => x.Price <= budget).OrderByDescending(x => x.OverallPerformance).FirstOrDefault();

            if (toRemove == null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            computers.Remove(toRemove);
            return toRemove.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == id);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComponent component = computer.RemoveComponent(componentType);
            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }
    }
}
