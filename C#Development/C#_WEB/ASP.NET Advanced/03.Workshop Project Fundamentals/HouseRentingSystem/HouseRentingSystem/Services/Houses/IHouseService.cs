using HouseRentingSystem.Services.Houses.Models;

namespace HouseRentingSystem.Services.Houses
{
    public interface IHouseService
    {
        HouseQueryServiceModel All(
           string category = null,
           string searchTerm = null,
           HouseSorting sorting = HouseSorting.Newest,
           int currentPage = 1,
           int housesPerPage = 1);
        bool CategoryExists(int categoryId);

        int Create(string title, string address,
            string description, string imageUrl, decimal price,
            int categoryId, int agentId);
        IEnumerable<HouseIndexServiceModel> LastThreeHouses();

        IEnumerable<HouseCategoryServiceModel> AllCategories();

        public IEnumerable<string> AllCategoriesNames();

        public IEnumerable<HouseServiceModel> AllHousesByAgentId(int agentId);

        public IEnumerable<HouseServiceModel> AllHousesByUserId(string userId);

        bool Exists(int id);

        HouseDetailsServiceModel HouseDetailsById(int id);
    }
}
