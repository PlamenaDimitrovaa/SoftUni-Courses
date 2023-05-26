using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Models;

namespace HouseRentingSystem.Services.Houses
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext data;

        public HouseService(HouseRentingDbContext data)
             => this.data = data;

        public IEnumerable<HouseIndexServiceModel> LastThreeHouses()
        => data.Houses
            .OrderByDescending(c => c.Id)
            .Select(c => new HouseIndexServiceModel()
            {
                Id = c.Id,
                Title = c.Title,
                ImageUrl = c.ImageUrl
            })
            .Take(3);
    }
}
