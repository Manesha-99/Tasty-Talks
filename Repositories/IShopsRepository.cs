using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IShopsRepository
    {
        Task<Shop> CreateShopAsync(Shop shops);
        Task<List<Shop>> GetShopsAsync(string? filterOn=null, string? filterQuery=null, string? sortBy=null, bool isAscending=true,
            int pageNumber = 1, int pageSize = 10);

        Task<Shop> GetShopByIdAsync(int id);

        Task<Shop> UpdateShopAsync(int id, Shop shops);
        
        Task<Shop> DeleteShopAsync(int id);
    }
}
