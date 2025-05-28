using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext(DbContextOptions<StoreContext> options) : IdentityDbContext<User>(options)
    {
        public required DbSet<Product> Products { get; set; }
        public required DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Id = "5d3d8774-06f0-4203-904b-37fda0cb698a", Name = "Member", NormalizedName = "MEMBER" },
                    new IdentityRole { Id = "762a9bf8-5d9d-4e4c-bde4-07cbde39553f", Name = "Admin", NormalizedName = "ADMIN" }
                );
        }
    }
}
