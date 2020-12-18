using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TechShop_Manager.BUS;

namespace TechShop_Manager.DAL {
    public class ShopContext : DbContext
    {
        // Your context has been configured to use a 'ShopContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TechShop_Manager.ShopContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ShopContext' 
        // connection string in the application configuration file.
        public ShopContext() : base("HoangShopContext")
        {
            // Database.SetInitializer(new ShopInitializer());
            Database.SetInitializer<ShopContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComboDetail>()
                .HasKey(a => new {a.ProductId, a.ComboId});
            modelBuilder.Entity<OrderDetail>()
                .HasKey(a => new {a.ProductId, a.OrderId});
            modelBuilder.Entity<ImportDetail>()
                .HasKey(a => new {a.ProductId, a.ImportId});
            
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboDetail> ComboDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Import> Imports { get; set; }
        public DbSet<ImportDetail> ImportDetails { get; set; }
    }
}