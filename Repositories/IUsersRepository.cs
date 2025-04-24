using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IUsersRepository
    {
        Task<User> CreateuserAsync(User users);
        Task<List<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<User> UpdateUserAsync(int id, User users);

        Task<User> DeleteUserAsync(int id);  
    }
}
