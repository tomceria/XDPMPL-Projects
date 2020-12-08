using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services.IService
{
    public interface IStaffService
    {
        IEnumerable<Staff> GetAllStaffs();
        Staff GetOneStaff(int id);
        IEnumerable<ApplicationUser> GetAllUsers();
        ApplicationUser GetUser(int staffId);
        ApplicationUser GetCurrentUser(ClaimsPrincipal user);
        void AddStaff(Staff staff);
        void UpdateStaff(Staff staff);
        void RemoveStaff(Staff staff);
    }
}