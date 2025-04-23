using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IFoodRepository
    {
        Task<Foods> CreateFoodAsync(Foods foods);

        Task<List<Foods>> GetAllFoodsAsync();

        Task<Foods> GetFoodByIdAsync(int id);

        Task<Foods> UpdateFoodAsync(int id, Foods foods);

        Task<Foods> DeleteFoodAsync(int id); 
    }
}
