using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            //var salesJson = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSuppliers(context, suppliersJson));
            //Console.WriteLine(ImportParts(context, partsJson));
            //Console.WriteLine(ImportCars(context, carsJson));
            //Console.WriteLine(ImportCustomers(context, customersJson));
            //Console.WriteLine(ImportSales(context, salesJson));

            //var result = GetOrderedCustomers(context);
            //var result = GetCarsFromMakeToyota(context);
            //var result = GetLocalSuppliers(context);
            //var result = GetCarsWithTheirListOfParts(context);
            //var result = GetTotalSalesByCustomer(context);
            var result = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },

                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(p => p.Part.Price) - (s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100):F2}"
                })
                .ToList();

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(sales, jsonSerializerSettings);

            return json;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(customers, jsonSerializerSettings);

            return json;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },

                    parts = c.PartCars
                        .Select(p => new
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price.ToString("F2")
                        })
                })
                .ToList();

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(cars, jsonSerializerSettings);

            return json;
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(suppliers, jsonSerializerSettings);

            return json;
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
              .Where(c => c.Make == "Toyota")
              .Select(c => new
              {
                  Id = c.Id,
                  Make = c.Make,
                  Model = c.Model,
                  TravelledDistance = c.TravelledDistance
              })
              .OrderBy(c => c.Model)
              .ThenByDescending(c => c.TravelledDistance)
              .ToList();

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(cars, jsonSerializerSettings);

            return json;
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .ToList()
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToList();

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(customers, jsonSerializerSettings);

            return json;
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesDtos = JsonConvert.DeserializeObject<IEnumerable<ImportSalesInputModel>>(inputJson);

            var sales = salesDtos.Select(x => new Sale
            {
                Discount = x.Discount,
                CarId = x.CarId,
                CustomerId = x.CustomerId
            });

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersDtos = JsonConvert.DeserializeObject<IEnumerable<ImportCustomerInputModel>>(inputJson);
            var customers = customersDtos.Select(x => new Customer
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungDriver,
            })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(inputJson);

            var listOfCars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                listOfCars.Add(currentCar);
            }

            context.Cars.AddRange(listOfCars);
            context.SaveChanges();

            return $"Successfully imported {listOfCars.Count}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliedIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var partsDtos = JsonConvert.DeserializeObject<IEnumerable<ImportPartsInputModel>>(inputJson)
                .Where(x => suppliedIds.Contains(x.SupplierId))
                .ToList();

            var parts = partsDtos.Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersDtos = JsonConvert.DeserializeObject<IEnumerable<ImportSupplierInputModel>>(inputJson);

            var suppliers = suppliersDtos.Select(x => new Supplier
                {
                    Name = x.Name,
                    IsImporter = x.IsImporter
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }
    }
}