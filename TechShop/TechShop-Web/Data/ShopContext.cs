using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechShop_Web.Models;

namespace TechShop_Web.Data
{
    public class ShopContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<ComboDetail>()
                .HasKey(a => new {a.ProductId, a.ComboId});
            builder.Entity<OrderDetail>()
                .HasKey(a => new {a.ProductId, a.OrderId});
            builder.Entity<ProductType>()
                .HasOne(o => o.ParentType)
                .WithMany(o => o.ProductTypes)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboDetail> ComboDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}