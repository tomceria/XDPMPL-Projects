using System.Collections.Generic;
using System.Linq;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI.DAL
{
    class CustomerDAL
    {
        static TourContext _ctx = new TourContext();

        public CustomerDAL()
        {
            _ctx = new TourContext();
        }

        public static List<Customer> GetAll()
        {
            var customers = _ctx.Customers.ToList();

            return customers;
        }
        public static Customer GetOne(int id)
        {
            // if found => return customer, else return null
            return _ctx.Customers.Find(id);
        }

        public static void CreateOne(Customer customer)
        {
            _ctx.Customers.Add(customer);
            _ctx.SaveChanges();
        }

        public static Customer UpdateOne(Customer customer)
        {
            // get by id
            var customerToUpdate = _ctx.Customers.Find(customer.ID);

            // update entity
            customerToUpdate.Name = customer.Name;

            // save change to db
            _ctx.SaveChanges();

            return customerToUpdate;
        }

        public static void DeleteOne(int id)
        {
            var customer = _ctx.Customers.Find(id);
            _ctx.Customers.Remove(customer);
            _ctx.SaveChanges();
        }
    }
}
