using BeautyBazaar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeautyBazaar.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(entity =>
            {
                entity.HasIndex(p => p.Category);
                entity.HasIndex(p => p.Brand);
                entity.HasIndex(p => p.IsActive);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
            });
        }
    }
}