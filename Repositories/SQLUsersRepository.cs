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
        public async Task<User> CreateuserAsync(User users)
        {
            await tastyTalksDbContext.User.AddAsync(users);
            await tastyTalksDbContext.SaveChangesAsync();

            return users;
        }


        //Delete User Function----------
        public async Task<User> DeleteUserAsync(int id)
        {
            var user = await tastyTalksDbContext.User.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) {

                return null;
            }

            tastyTalksDbContext.User.Remove(user);
            await tastyTalksDbContext.SaveChangesAsync();
            
            return user;
        }


        //Get USERS--------------
        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await tastyTalksDbContext.User.FirstOrDefaultAsync(x=>x.Id==id);

            if (user == null) {
                return null;
            }

            return user;
        }


        
        public async Task<List<User>> GetUsersAsync()
        {
            var users = await tastyTalksDbContext.User.ToListAsync();

            return users;
        }


        //Update User Function----------
        public async Task<User> UpdateUserAsync(int id, User users)
        {
            var existingUser = await tastyTalksDbContext.User.FirstOrDefaultAsync(x=>x.Id==id);

            if (existingUser == null) {

                return null;
            
            }

            existingUser.Email = users.Email;
            existingUser.Name = users.Name;
            existingUser.Password = users.Password;
            existingUser.Phone = users.Phone;

            await tastyTalksDbContext.SaveChangesAsync();

            return existingUser;
        }
    }
}
