using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TodoList.Models;

namespace TodoList.Persistence.Interfaces
{
    public interface IAccountRepository
    {
        Task<SignInResult> LoginAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task LogoutAsync();
        Task<ApplicationUser> GetUserAsync(string userName);
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role);
        Task<IEnumerable<string>> GetUserRolesAsync(string userName);
        Task<IdentityRole> GetRoleAsync(string name);
        IEnumerable<IdentityRole> GetAllRoles();
        Task<IdentityResult> CreateRoleAsync(IdentityRole role);
        Task<bool> IsInRoleAsync(ApplicationUser user, string role);
        Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string role);
        Task<IdentityResult> RemoveFromRolesAsync(ApplicationUser user, IEnumerable<string> roles);
        Task<IdentityResult> UpdateAsync(ApplicationUser user);
        IQueryable<ApplicationUser> GetAll();
    }
}