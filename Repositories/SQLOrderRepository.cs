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

        //Create Order Function-----
        public async Task<Order> CreateAsync(Order order)
        {
            await tastyTalksDbContext.Order.AddAsync(order);
            await tastyTalksDbContext.SaveChangesAsync();

            return order;

        }

        //Delete Order Function----
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


        //Read Order Function----
        public async Task<List<Order>> GetAllAsync()
        {
            var orders = await tastyTalksDbContext.Order.ToListAsync();

            return orders;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await tastyTalksDbContext.Order.FirstOrDefaultAsync(x=>x.Id==id);
            if (order == null) {
                return null;
            }

            return order;
        }

    
        //Update Order Function----
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
