using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportPartDto, Part>()
                .ForMember(d => d.SupplierId,
                    opt => opt.MapFrom(s => s.SupplierId!.Value));


            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(s => s.Parts,
                    opt => opt.DoNotValidate());

            this.CreateMap<ImportCustomerDto, Customer>()
                .ForMember(d => d.BirthDate,
                    opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

            this.CreateMap<ImportSaleDto, Sale>()
                .ForMember(d => d.CarId,
                    opt => opt.MapFrom(s => s.CarId.Value));

            this.CreateMap<Car, ExportCarDto>();

            this.CreateMap<Car, ExportBMWCarDto>();

            this.CreateMap<Supplier, ExportLocalSupplierDto>();

            this.CreateMap<Part, ExportPartDto>();

            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Parts,
                    opt => opt.MapFrom(s => s.PartsCars
                    .Select(pc => pc.Part)
                    .OrderByDescending(p => p.Price)
                    .ToArray()));

            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d => d.BoughtCars, 
                    opt => opt.MapFrom(s => s.Sales.Count))
                .ForMember(d => d.SpentMoney,
                opt => opt.MapFrom(x => x.Sales
                            .Select(x => x.Car)
                            .SelectMany(x => x.PartsCars)
                            .Sum(x => x.Part.Price)));
        }
    }
}
