using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IFoodRepository
    {
        Task<Food> CreateFoodAsync(Food foods);

        Task<List<Food>> GetAllFoodsAsync();

        Task<Food> GetFoodByIdAsync(int id);

        Task<Food> UpdateFoodAsync(int id, Food foods);

        Task<Food> DeleteFoodAsync(int id); 
    }
}
