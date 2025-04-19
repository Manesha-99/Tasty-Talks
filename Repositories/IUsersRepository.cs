using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IUsersRepository
    {
        Task<Users> CreateuserAsync(Users users);
        Task<List<Users>> GetUsersAsync();

        Task<Users> GetUserByIdAsync(int id);

        Task<Users> UpdateUserAsync(int id, Users users);

        Task<Users> DeleteUserAsync(int id);  
    }
}
