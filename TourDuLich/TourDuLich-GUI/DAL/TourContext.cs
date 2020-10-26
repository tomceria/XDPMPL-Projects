using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI.DAL {
    public class TourContext : DbContext {
        // Your context has been configured to use a 'TourContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TourDuLich_GUI.TourContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TourContext' 
        // connection string in the application configuration file.
        public TourContext() : base("TDLMinhHoangPCContext") {
            Database.SetInitializer(new TourInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TourPrice>()
                .HasRequired<Tour>(o => o.Tour).WithMany(o => o.TourPrices).HasForeignKey<int>(o => o.TourID)
                .WillCascadeOnDelete(true);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<TourPrice> TourPrices { get; set; }
        public DbSet<TourGroup> TourGroups { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<CostType> CostTypes { get; set; }
        public DbSet<TourDetail> TourDetails { get; set; }
        public DbSet<TourGroupCost> TourGroupCosts { get; set; }
        public DbSet<TourGroupDetail> TourGroupDetails { get; set; }
        public DbSet<TourGroupStaff> TourGroupStaffs { get; set; }

        //public class MyEntity
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //}
    }
}