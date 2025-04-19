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


        //Create Shop Async-------
        public async Task<Shops> CreateShopAsync(Shops shops)
        {
            await tastyTalksDbContext.Shops.AddAsync(shops);
            await tastyTalksDbContext.SaveChangesAsync();

            return shops;
        }


        //Delete Shop Async--------
        public async Task<Shops> DeleteShopAsync(int id)
        {
            var shop = await tastyTalksDbContext.Shops.FirstOrDefaultAsync(x => x.Id == id);

            if (shop == null) {

                return null;
            }

            tastyTalksDbContext.Shops.Remove(shop);
            await tastyTalksDbContext.SaveChangesAsync();

            return shop;
        }


        //Get Shop Async---------
        public async Task<Shops> GetShopByIdAsync(int id)
        {
            var shop = await tastyTalksDbContext.Shops.FirstOrDefaultAsync(x => x.Id == id);

            if (shop == null) {

                return null;
            }

            return shop;
        }


        
        public async Task<List<Shops>> GetShopsAsync()
        {
            var shops = await tastyTalksDbContext.Shops.ToListAsync();

            return shops;
        }


        //Update Shops Function---------

        public async Task<Shops> UpdateShopAsync(int id, Shops shops)
        {
            var existingModel = await tastyTalksDbContext.Shops.FirstOrDefaultAsync(x=>x.Id== id);

            if (existingModel == null) {

                return null;

            }

            existingModel.ShopName = shops.ShopName;
            existingModel.Address = shops.Address;
            existingModel.CloseTime = shops.CloseTime;
            existingModel.Description = shops.Description;
            existingModel.OpenTime = shops.OpenTime;
            existingModel.Status = shops.Status;
            existingModel.ImageUrl = shops.ImageUrl;

            await tastyTalksDbContext.SaveChangesAsync();

            return existingModel;
           


        }


        

       
    }
}
