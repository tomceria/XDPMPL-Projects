using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS
{
    public partial class Order
    {
        public static List<Order> GetAll()
        {
            return OrderDAL.GetAll();
        }

        public static Order GetOne(int id)
        {
            return OrderDAL.GetOne(id);
        }
    }
}
