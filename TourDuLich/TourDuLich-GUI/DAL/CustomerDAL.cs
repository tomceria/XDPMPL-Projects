using System.Collections.Generic;
using System.Linq;
using TourDuLich_GUI.Models;

namespace TourDuLich_GUI.DAL
{
    class CustomerDAL
    {
        private TourContext _ctx;

        public CustomerDAL()
        {
            _ctx = new TourContext();
        }

        public List<Customer> GetAll()
        {
            var customers = _ctx.Customers.ToList();

            return customers;
        }
        public Customer GetOne(int id)
        {
            // if found => return customer, else return null
            return _ctx.Customers.Find(id);
        }

        public void CreateOne(Customer customer)
        {
            _ctx.Customers.Add(customer);
            _ctx.SaveChanges();
        }

        public Customer UpdateOne(Customer customer)
        {
            // get by id
            var customerToUpdate = _ctx.Customers.Find(customer.ID);

            // update entity
            customerToUpdate.Name = customer.Name;

            // save change to db
            _ctx.SaveChanges();

            return customerToUpdate;
        }

        public void DeleteOne(int id)
        {
            var customer = _ctx.Customers.Find(id);
            _ctx.Customers.Remove(customer);
            _ctx.SaveChanges();
        }
    }
}
