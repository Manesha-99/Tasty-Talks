using Tasty_Talks_BackEnd.Data;
using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public class SQLShopsRepository : IShopsRepository
    {
        private readonly TastyTalksDbContext tastyTalksDbContext;

        public SQLShopsRepository(TastyTalksDbContext tastyTalksDbContext)
        {
            this.tastyTalksDbContext = tastyTalksDbContext;
        }
        public async Task<Shops> CreateShopAsync(Shops shops)
        {
            await tastyTalksDbContext.Shops.AddAsync(shops);
            await tastyTalksDbContext.SaveChangesAsync();

            return shops;
        }
    }
}
