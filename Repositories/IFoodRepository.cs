using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IFoodRepository
    {
        Task<Food> CreateFoodAsync(Food foods);

        Task<List<Food>> GetAllFoodsAsync(string? filterOn=null, string? filterQuery=null, string? sortBy=null, bool isAscending=true,
            int pageNumber=1, int pageSize=10);

        Task<Food> GetFoodByIdAsync(int id);

        Task<Food> UpdateFoodAsync(int id, Food foods);

        Task<Food> DeleteFoodAsync(int id); 
    }
}
