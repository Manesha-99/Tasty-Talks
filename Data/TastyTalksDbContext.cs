using Microsoft.EntityFrameworkCore;
using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Data
{
    public class TastyTalksDbContext:DbContext

    {
        public TastyTalksDbContext(DbContextOptions<TastyTalksDbContext> dbContextOptions): base(dbContextOptions)
        {

        }
        
        public DbSet<Shop> Shop { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<FoodCategory> FoodCategory { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

