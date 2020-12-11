using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechShop_Web.Data;
using TechShop_Web.Models;
using TechShop_Web.Persistence.Interfaces;

namespace TechShop_Web.Persistence.Repositories
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
                where user.UserName.Equals(username)
                select user
            ).Include(o => o.Staff)
            .First();
        }

        public ApplicationUser GetUserWithStaff(int staffId)
        {
            return (
                from user in Context.Users
                join staff in Context.Staffs
                    on user.StaffId equals staff.Id
                where staff.Id == staffId
                select user
            ).Include(o => o.Staff)
            .First();
        }

        public override Staff GetBy(int id)
        {
            return Context.Staffs
                .FirstOrDefault(o => o.Id == id);
        }
    }
}