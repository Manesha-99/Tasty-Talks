using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IShopsRepository
    {
        Task<Shops> CreateShopAsync(Shops shops);
        Task<List<Shops>> GetShopsAsync();

        Task<Shops> GetShopByIdAsync(int id);

        Task<Shops> UpdateShopAsync(int id, Shops shops);
        
        Task<Shops> DeleteShopAsync(int id);
    }
}
