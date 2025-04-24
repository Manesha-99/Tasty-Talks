using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IFoodCategoryRepository
    {
        Task<FoodCategory> CreateAsync(FoodCategory foodCategory);

        Task<List<FoodCategory>> GetAllAsync(string? filterOn=null, string? filterQuery=null, string? sortBy=null, bool isAscending=true,
            int pageNumber = 1, int pageSize = 10);

        Task<FoodCategory> GeByIdAsync(int id);

        Task<FoodCategory> UpdateAsync(int id, FoodCategory foodCategory);

        Task<FoodCategory> DeleteAsync(int id);
    }
}
