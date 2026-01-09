using FastKart.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FastKart.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet <BasketItem> BasketItems { get; set; }

    }
}
