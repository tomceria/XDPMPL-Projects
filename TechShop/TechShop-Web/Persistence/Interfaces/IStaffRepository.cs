using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.Persistence.Interfaces
{
    public interface IStaffRepository : IRepository<Staff>
    {
        public IEnumerable<ApplicationUser> GetAllUsers();
        public ApplicationUser GetUserWithStaff(string username);
        public ApplicationUser GetUserWithStaff(int staffId);
    }
}