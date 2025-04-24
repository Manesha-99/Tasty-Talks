using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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


        //Create Shop Async-------------------------------
        public async Task<Shop> CreateShopAsync(Shop shops)
        {
            await tastyTalksDbContext.Shop.AddAsync(shops);
            await tastyTalksDbContext.SaveChangesAsync();

            return shops;
        }


        //Delete Shop Async-------------------------------
        public async Task<Shop> DeleteShopAsync(int id)
        {
            var shop = await tastyTalksDbContext.Shop.FirstOrDefaultAsync(x => x.Id == id);

            if (shop == null) {

                return null;
            }

            tastyTalksDbContext.Shop.Remove(shop);
            await tastyTalksDbContext.SaveChangesAsync();

            return shop;
        }


        //Get Shop Async----------------------------------
        public async Task<Shop> GetShopByIdAsync(int id)
        {
            var shop = await tastyTalksDbContext.Shop.FirstOrDefaultAsync(x => x.Id == id);

            if (shop == null) {

                return null;
            }

            return shop;
        }



        public async Task<List<Shop>> GetShopsAsync(string? filterOn = null, string? filterQuery=null, 
            string? sortBy = null, bool isAscending = true, int pageNumber=1, int pageSize=10)
        {
            var shop = tastyTalksDbContext.Shop.Include("User").AsQueryable();

            //Filtering By ShopName----

            if (string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery)==false)
            {
                if (filterOn.Equals("ShopName", StringComparison.OrdinalIgnoreCase))
                {
                    shop = shop.Where(x=>x.ShopName.Contains(filterQuery));
                }
            }

            //Sorting----

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("ShopName", StringComparison.OrdinalIgnoreCase))
                {
                    shop = isAscending? shop.OrderBy(x=>x.ShopName) : shop.OrderByDescending(x=>x.ShopName);
                }
            }

            //Pagination----

            var skipResults = (pageNumber - 1) * pageSize;


            return await shop.Skip(skipResults).Take(pageSize).ToListAsync();
        }


        //Update Shops Function-----------------------------

        public async Task<Shop> UpdateShopAsync(int id, Shop shops)
        {
            var existingModel = await tastyTalksDbContext.Shop.FirstOrDefaultAsync(x=>x.Id== id);

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
