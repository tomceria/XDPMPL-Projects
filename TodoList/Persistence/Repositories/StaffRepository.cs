using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Persistence.Interfaces;

namespace TodoList.Persistence.Repositories
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        protected TodoContext Context => DbContext as TodoContext;

        public StaffRepository(TodoContext context) : base(context)
        {
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return Context.Users
                .Include(o => o.Staff)
                .OrderBy(o => o.Staff.Id)
                .Select(o => o);
        }

        public ApplicationUser GetUserWithStaff(string username)
        {
            return (
                from user in Context.Users
                join staff in Context.Staffs
                    on user.StaffId equals staff.Id
                where user.UserName == username
                select user
            ).First();
        }
    }
}