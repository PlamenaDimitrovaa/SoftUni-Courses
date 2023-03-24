using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            //string inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            string result = GetSoldProducts(context);
            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportUserDto[] userDtos =
                xmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            ICollection<User> validUsers = new HashSet<User>();

            foreach (var userDto in userDtos)
            {
                if (string.IsNullOrEmpty(userDto.FirstName) ||
                    string.IsNullOrEmpty(userDto.LastName))
                {
                    continue;
                }

                User user = mapper.Map<User>(userDto);
                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportProductDto[] productDtos =
                xmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");

            ICollection<Product> validProducts = new HashSet<Product>();

            foreach (var productDto in productDtos)
            {
                if (string.IsNullOrEmpty(productDto.Name))
                {
                    continue;
                }

                Product product = mapper.Map<Product>(productDto);  
                validProducts.Add(product);
            }
            
            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ICollection<Category> validCategories = new HashSet<Category>();

            ImportCategoryDto[] categoryDtos =
                xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");
            foreach (var catDto in categoryDtos)
            {
                if (string.IsNullOrEmpty(catDto.Name))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(catDto);
                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();

            ImportCategoryProductDto[] categoryProductDtos = xmlHelper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

            foreach (var catProdDto in categoryProductDtos)
            {
                if (string.IsNullOrEmpty(catProdDto.CategoryId.ToString()) || 
                    string.IsNullOrEmpty(catProdDto.ProductId.ToString()))
                {
                    continue;
                }

                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(catProdDto);
                validCategoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportProductInRangeDto[] products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportProductInRangeDto[]>(products, "Products");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportUserProductDto[] users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<ExportUserProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(users, "Users");
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCategoryByProductCountDto[] categoriesByProductsCount = context.Categories
                .ProjectTo<ExportCategoryByProductCountDto>(mapper.ConfigurationProvider)
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            return xmlHelper.Serialize(categoriesByProductsCount, "Categories");
        }

        private static IMapper InitializeAutoMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }
    }
}