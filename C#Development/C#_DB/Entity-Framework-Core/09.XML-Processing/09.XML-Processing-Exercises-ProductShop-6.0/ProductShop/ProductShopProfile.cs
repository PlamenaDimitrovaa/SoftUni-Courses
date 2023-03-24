using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(p => p.Buyer,
                    opt => opt.MapFrom(p => p.Buyer.FirstName + ' ' + p.Buyer.LastName));

            this.CreateMap<User, ExportUserProductDto>();
            this.CreateMap<Product, ExportProductSoldDto>();

            this.CreateMap<Category, ExportCategoryByProductCountDto>()
                  .ForMember(p => p.Count,
                    opt => opt.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(p => p.AveragePrice,
                    opt => opt.MapFrom(src => src.CategoryProducts
                        .Average(cp => cp.Product.Price)))
                .ForMember(p => p.TotalRevenue,
                    opt => opt.MapFrom(src => src.CategoryProducts
                        .Sum(cp => cp.Product.Price)));
        }
    }
}
