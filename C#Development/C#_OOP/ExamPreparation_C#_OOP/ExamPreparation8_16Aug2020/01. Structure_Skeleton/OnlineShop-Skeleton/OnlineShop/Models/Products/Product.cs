using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id can not be less or equal than 0.");
                }

                id = value;
            }
        }

        public string Manufacturer
        {
            get => manufacturer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer can not be empty.");
                }

                manufacturer = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model can not be empty.");
                }

                model = value;
            }
        }

        public virtual decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can not be less or equal than 0.");
                }

                price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => overallPerformance;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Overall Performance can not be less or equal than 0.");
                }

                overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} -" +
              $" {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
        }
    }
}
