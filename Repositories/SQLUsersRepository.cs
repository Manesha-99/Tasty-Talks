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


        //Delete User Function----------
        public async Task<Users> DeleteUserAsync(int id)
        {
            var user = await tastyTalksDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) {

                return null;
            }

            tastyTalksDbContext.Users.Remove(user);
            await tastyTalksDbContext.SaveChangesAsync();
            
            return user;
        }


        //Get USERS--------------
        public async Task<Users> GetUserByIdAsync(int id)
        {
            var user = await tastyTalksDbContext.Users.FirstOrDefaultAsync(x=>x.Id==id);

            if (user == null) {
                return null;
            }

            return user;
        }


        
        public async Task<List<Users>> GetUsersAsync()
        {
            var users = await tastyTalksDbContext.Users.ToListAsync();

            return users;
        }


        //Update User Function----------
        public async Task<Users> UpdateUserAsync(int id, Users users)
        {
            var existingUser = await tastyTalksDbContext.Users.FirstOrDefaultAsync(x=>x.Id==id);

            if (existingUser == null) {

                return null;
            
            }

            existingUser.Email = users.Email;
            existingUser.Address = users.Address;
            existingUser.Name = users.Name;
            existingUser.Password = users.Password;
            existingUser.Phone = users.Phone;

            await tastyTalksDbContext.SaveChangesAsync();

            return existingUser;
        }
    }
}
