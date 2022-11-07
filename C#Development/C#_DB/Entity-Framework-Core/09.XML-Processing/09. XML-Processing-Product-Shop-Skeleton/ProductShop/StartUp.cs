using ProductShop.Data;
using ProductShop.DataTransferObjects.Input;
using ProductShop.DataTransferObjects.Output;
using ProductShop.Models;
using ProductShop.XMLHepler;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var usersXml = File.ReadAllText("./Datasets/users.xml");
            //var productsXml = File.ReadAllText("./Datasets/products.xml");
            //var categoriesXml = File.ReadAllText("./Datasets/categories.xml");
            //var categoriesAndProductsXml = File.ReadAllText("./Datasets/categories-products.xml");

            //ImportUsers(context, usersXml);
            //ImportProducts(context, productsXml);
            //ImportCategories(context, categoriesXml);
            //var result = ImportCategoryProducts(context, categoriesAndProductsXml);
            //Console.WriteLine(result);

            Console.WriteLine(GetProductsInRange(context));
        }

        //public static string GetSoldProducts(ProductShopContext context)
        //{
        //    var users = context.Users
        //       .Select(x => new UserOutputModel
        //       {
                  
        //       })
        //       .ToArray();

        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserOutputModel[]), new XmlRootAttribute("Users"));
        //    var textWriter = new StringWriter();
        //    xmlSerializer.Serialize(textWriter, users);
        //    var result = textWriter.ToString();
        //    return result;
        //}
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .ToArray()
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductOutputModel
                {
                      Name = x.Name,
                      Price = x.Price,
                      Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            var result = XmlConverter.Serialize(products, "Products");
            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryProductsInputModel[]), new XmlRootAttribute("CategoryProducts"));
            var textReader = new StringReader(inputXml);
            var categoryProductsDto = xmlSerializer.Deserialize(textReader) as CategoryProductsInputModel[];

            var categoryProducts = categoryProductsDto
                .Select(x => new CategoryProduct
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId
                }).ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryInputModel[]), new XmlRootAttribute("Categories"));
            var textReader = new StringReader(inputXml);
            var categoriesDto = xmlSerializer.Deserialize(textReader) as CategoryInputModel[];

            var categories = categoriesDto
                .Where(x => x.Name != null)
                .Select(x => new Category
                {
                    Name = x.Name
                }).ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute("Products"));
            var textReader = new StringReader(inputXml);
            var productsDto = xmlSerializer.Deserialize(textReader) as ProductInputModel[];

            var products = productsDto.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                SellerId = x.SellerId,
                BuyerId = x.BuyerId
            }).ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(UserInputModel[]), new XmlRootAttribute("Users"));
            var textReader = new StringReader(inputXml);
            var usersDto = xmlSerializer.Deserialize(textReader) as UserInputModel[];

            var users = usersDto.Select(x => new User
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age
            }).ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}