using Microsoft.EntityFrameworkCore;
using Tasty_Talks_BackEnd.Data;
using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public class SQLOrderRepository: IOrderRepository
    {
        private readonly TastyTalksDbContext tastyTalksDbContext;

        public SQLOrderRepository(TastyTalksDbContext tastyTalksDbContext)
        {
            this.tastyTalksDbContext = tastyTalksDbContext;
        }

        //Create Order Function----------------------------------------------------
        public async Task<Order> CreateAsync(Order order)
        {
            await tastyTalksDbContext.Order.AddAsync(order);
            await tastyTalksDbContext.SaveChangesAsync();

            return order;

        }


        //Delete Order Function----------------------------------------------------
        public async Task<Order> DeleteAsync(int id)
        {
            var existingOrder = await tastyTalksDbContext.Order.FirstOrDefaultAsync(x => x.Id == id);
            if (existingOrder == null) {
                return null;
            }

            tastyTalksDbContext.Order.Remove(existingOrder);
            await tastyTalksDbContext.SaveChangesAsync();

            return existingOrder;
            
        }


        //Read Order Function------------------------------------------------------
        public async Task<List<Order>> GetAllAsync(string? filterOn=null, string? filterQuery = null,
            string ? sortBy = null, bool isAscending = false, int pageNumber = 1, int pageSize = 10)
        {
            var order = tastyTalksDbContext.Order.Include("User").Include("Shop").AsQueryable();

            //Filering

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Shop_Id", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(filterQuery, out int shopId))
                    {
                        order = order.Where(x => x.Shop_Id == shopId);
                    }
                }
            }


            //Sorting----

            if (string.IsNullOrWhiteSpace(sortBy) == false) { 
            
                if(sortBy.Equals("Id", StringComparison.OrdinalIgnoreCase)){

                    order = isAscending? order.OrderBy(x=>x.Id) : order.OrderByDescending(x=>x.Id);
                }

            }

            //Pagination----

            var skipResults = (pageNumber - 1) * pageSize;

            return await order.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await tastyTalksDbContext.Order.FirstOrDefaultAsync(x=>x.Id==id);
            if (order == null) {
                return null;
            }

            return order;
        }

    
        //Update Order Function----------------------------------------------------
        public async Task<Order> UpdateAsync(int id, Order order)
        {
            var existingOrder = await tastyTalksDbContext.Order.FirstOrDefaultAsync(x=>x.Id==id);
            if (existingOrder == null) {
                return null;
            }

            existingOrder.Progress = order.Progress;

            await tastyTalksDbContext.SaveChangesAsync();

            return existingOrder;
        }
    }
}
