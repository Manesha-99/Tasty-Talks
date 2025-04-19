using Microsoft.EntityFrameworkCore;
using Tasty_Talks_BackEnd.Data;
using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public class SQLUsersRepository: IUsersRepository
    {
        private readonly TastyTalksDbContext tastyTalksDbContext;

        public SQLUsersRepository(TastyTalksDbContext tastyTalksDbContext)
        {
            this.tastyTalksDbContext = tastyTalksDbContext;
        }

        //Create a USER----------
        public async Task<Users> CreateuserAsync(Users users)
        {
            await tastyTalksDbContext.Users.AddAsync(users);
            await tastyTalksDbContext.SaveChangesAsync();

            return users;
        }


        //Get USERS--------------
        public async Task<List<Users>> GetUsersAsync()
        {
            var users = await tastyTalksDbContext.Users.ToListAsync();

            return users;
        }
    }
}
