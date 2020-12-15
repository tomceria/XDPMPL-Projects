using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Persistence.Interfaces
{
    public interface IStaffRepository : IRepository<Staff>
    {
        public IEnumerable<ApplicationUser> GetAllUsers();
        public ApplicationUser GetUserWithStaff(string username);
        public ApplicationUser GetUserWithStaff(int staffId);
    }
}