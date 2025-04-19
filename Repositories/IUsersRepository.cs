using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public interface IUsersRepository
    {
        Task<Users> CreateuserAsync(Users users);
        Task<List<Users>> GetUsersAsync();
    }
}
