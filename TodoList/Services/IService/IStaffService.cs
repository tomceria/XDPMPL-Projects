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
        IEnumerable<ApplicationUser> GetAllUsers();
        ApplicationUser GetCurrentUser(ClaimsPrincipal user);
        void AddStaff(Staff staff);
        void RemoveStaff(Staff staff);
    }
}