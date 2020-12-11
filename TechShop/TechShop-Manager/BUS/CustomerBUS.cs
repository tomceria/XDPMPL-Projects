using System.Collections.Generic;
using TechShop_Manager.DAL;

namespace TechShop_Manager.BUS
{
    public partial class Customer
    {
        public static List<Customer> GetAll() {
            return CustomerDAL.GetAll();
        }

        public static Customer GetOne(int id)
        {
            return CustomerDAL.GetOne(id);
        }
    }
}
