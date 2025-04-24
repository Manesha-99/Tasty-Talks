using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IShopsRepository
    {
        Task<Shop> CreateShopAsync(Shop shops);
        Task<List<Shop>> GetShopsAsync();

        Task<Shop> GetShopByIdAsync(int id);

        Task<Shop> UpdateShopAsync(int id, Shop shops);
        
        Task<Shop> DeleteShopAsync(int id);
    }
}
