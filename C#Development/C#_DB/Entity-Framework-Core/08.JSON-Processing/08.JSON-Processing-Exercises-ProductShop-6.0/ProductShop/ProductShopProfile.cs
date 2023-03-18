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
            this.CreateMap<ImportUserDTO, User>();
            this.CreateMap<ImportProductDTO, Product>();
            this.CreateMap<ImportCategoryDTO, Category>();
            this.CreateMap<ImportCategoryProductDTO, CategoryProduct>();

            this.CreateMap<Product, ExportProductInRangeDTO>()
                .ForMember(d => d.ProductName,
                        opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.ProductPrice, 
                        opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.SellerName,
                        opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));
        }
    }
}
