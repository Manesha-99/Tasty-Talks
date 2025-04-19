using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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


        //Create Shop Async
        public async Task<Shops> CreateShopAsync(Shops shops)
        {
            await tastyTalksDbContext.Shops.AddAsync(shops);
            await tastyTalksDbContext.SaveChangesAsync();

            return shops;
        }


        //Get Shop Async
        public async Task<List<Shops>> GetShopsAsync()
        {
            var shops = await tastyTalksDbContext.Shops.ToListAsync();

            return shops;
        }
    }
}
