using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingNow.core.Entities;

namespace ShoppingNow.Infrastructure
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    FirstName = "Ahmed",
                    LastName = "Saied",
                    UserName = "Admin",
                    PasswordHash = "Admin123"
                });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Customer",
            },new IdentityRole
            {
                Name = "Admin"
            });
        base.OnModelCreating(builder);
        }
    }
}
