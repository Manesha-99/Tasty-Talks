using Tasty_Talks_BackEnd.Data;

namespace Tasty_Talks_BackEnd.Repositories
{
    public class SQLUsersRepository:IUsersRepository
    {
        private readonly TastyTalksDbContext tastyTalksDbContext;

        public SQLUsersRepository(TastyTalksDbContext tastyTalksDbContext)
        {
            this.tastyTalksDbContext = tastyTalksDbContext;
        }


    }
}
