using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IFoodCategoryRepository
    {
        Task<FoodCategory> CreateAsync(FoodCategory foodCategory);

        Task<List<FoodCategory>> GetAllAsync();

        Task<FoodCategory> GeByIdAsync(int id);

        Task<FoodCategory> UpdateAsync(int id, FoodCategory foodCategory);

        Task<FoodCategory> DeleteAsync(int id);
    }
}
