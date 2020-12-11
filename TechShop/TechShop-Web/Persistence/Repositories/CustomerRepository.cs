using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechShop_Web.Data;
using TechShop_Web.Models;
using TechShop_Web.Persistence.Interfaces;

namespace TechShop_Web.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        protected ShopContext Context => DbContext as ShopContext;

        public CustomerRepository(ShopContext context) : base(context)
        {
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return Context.Users
                .Include(o => o.Customer)
                .OrderBy(o => o.Customer.Id)
                .Select(o => o);
        }

        public ApplicationUser GetUserWithStaff(string username)
        {
            return (
                from user in Context.Users
                join staff in Context.Customers
                    on user.StaffId equals staff.Id
                where user.UserName.Equals(username)
                select user
            ).Include(o => o.Customer)
            .First();
        }

        public ApplicationUser GetUserWithStaff(int staffId)
        {
            return (
                from user in Context.Users
                join staff in Context.Customers
                    on user.StaffId equals staff.Id
                where staff.Id == staffId
                select user
            ).Include(o => o.Customer)
            .First();
        }

        public override Customer GetBy(int id)
        {
            return Context.Customers
                .FirstOrDefault(o => o.Id == id);
        }
    }
}