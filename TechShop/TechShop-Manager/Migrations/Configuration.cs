using TechShop_Manager.BUS;

namespace TechShop_Manager.Migrations {
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using TechShop_Manager.BUS;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ShopContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.ShopContext context) {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            
            // IMPORTANT: Please perform Seed on TechShop-Web
        }
    }
}
