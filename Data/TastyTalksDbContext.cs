using Microsoft.EntityFrameworkCore;
using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Data
{
    public class TastyTalksDbContext:DbContext

    {
        public TastyTalksDbContext(DbContextOptions<TastyTalksDbContext> dbContextOptions): base(dbContextOptions)
        {

        }
        
        public DbSet<Shops> Shops { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<Foods> Foods { get; set; }
            
        }
    }

