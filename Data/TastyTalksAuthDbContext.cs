using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tasty_Talks_BackEnd.Data
{
    public class TastyTalksAuthDbContext : IdentityDbContext
    {
        public TastyTalksAuthDbContext(DbContextOptions<TastyTalksAuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var customerRoleId = "b12cc102-d6aa-4663-bd59-a21e2b1e48cf";
            var sellerRoleId = "f2d1e00a-60b9-443e-a380-f8b5951877f2";
            var adminRoleId = "d966d438-904d-495a-a95c-2693b1391bc3";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = customerRoleId,
                    Name = "Customer",
                    ConcurrencyStamp = customerRoleId,
                    NormalizedName = "Customer".ToUpper()
                },
                new IdentityRole
                {
                    Id = sellerRoleId,
                    Name = "Seller",
                    ConcurrencyStamp = sellerRoleId,
                    NormalizedName = "Seller".ToUpper(),
                },
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    ConcurrencyStamp = adminRoleId,
                    NormalizedName = "Admin".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);


        }
    }
}
