using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop_Manager.BUS;

namespace TechShop_Manager.DAL
{
    class OrderDAL
    {
        static ShopContext _ctx = new ShopContext();
        public static List<Order> GetAll()
        {
            var order = _ctx.Orders.ToList();

            return order;
        }
        public static Order GetOne(int id)
        {
            return _ctx.Orders.Find(id);
        }
    }
}
