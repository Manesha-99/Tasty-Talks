using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<List<Order>> GetAllAsync(string? filterOn=null, string? filterQuery=null,
            string? sortBy=null, bool isAscending=false, int pageNumber=1, int pageSize=10);
        Task<Order> GetByIdAsync(int id);
        Task<Order> UpdateAsync(int id, Order order);
        Task<Order> DeleteAsync(int id);
    }
}
