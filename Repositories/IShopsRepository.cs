using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IShopsRepository
    {
        Task<Shops> CreateShopAsync(Shops shops);
    }
}
