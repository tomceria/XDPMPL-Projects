using System.Data.Entity;

namespace TechShop_Manager.DAL
{
    class ShopInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
        }
    }
}