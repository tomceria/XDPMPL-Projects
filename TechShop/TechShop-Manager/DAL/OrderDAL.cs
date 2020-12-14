using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TechShop_Manager.BUS;

namespace TechShop_Manager.DAL
{
    public class OrderDAL
    {
        static ShopContext _ctx = new ShopContext();

        public OrderDAL()
        {
            _ctx = new ShopContext();
        }
        
        public static List<Order> GetAll()
        {
            var imports = _ctx.Orders
                .Include(o => o.OrderDetails.Select(o => o.Product))
                .ToList();

            return imports;
        }
        public static Order GetOne(int id)
        {
            return _ctx.Orders.Find(id);
        }
    }
}