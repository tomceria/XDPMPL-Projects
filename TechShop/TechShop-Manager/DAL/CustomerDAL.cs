using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TechShop_Manager.BUS;

namespace TechShop_Manager.DAL
{
    class CustomerDAL
    {
        static ShopContext _ctx = new ShopContext();

        public CustomerDAL()
        {
            _ctx = new ShopContext();
        }

        public static List<Customer> GetAll()
        {
            var customers = _ctx.Customers.ToList();

            return customers;
        }
        public static Customer GetOne(int id)
        {
            return _ctx.Customers.Find(id);
        }

        public static void AddOne(Customer customer)
        {
            _ctx.Customers.Add(customer);
            _ctx.SaveChanges();
        }

        public static Customer UpdateOne(Customer customer)
        {
            _ctx.Entry(customer).State = EntityState.Modified;    

            _ctx.SaveChanges();

            return customer;
        }
    }
}
