using TechShop_Web.Data;
using TechShop_Web.Models;
using TechShop_Web.Persistence.Interfaces;

namespace TechShop_Web.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        protected ShopContext Context => DbContext as ShopContext;

        public OrderRepository(ShopContext context) : base(context)
        {
        }
    }
}