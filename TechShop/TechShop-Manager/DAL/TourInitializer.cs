using System.Data.Entity;

namespace TechShop_Manager.DAL
{
    class TourInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
        }
    }
}