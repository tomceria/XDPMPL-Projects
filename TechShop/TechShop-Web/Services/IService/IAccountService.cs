using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TechShop_Web.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TechShop_Web.Services.IService
{
    public interface IAccountService
    {
        public Task<SignInResult> Login(string username, string password);
        public Task Logout();
        Task<ApplicationUser> GetUser(string username);
        public Task<IdentityResult> CreateAndAddUser(string username, string password, Staff staff);
        public Task<IEnumerable<string>> GetUserRoles(string username);
        public Task<bool> IsInRole(ApplicationUser applicationUser, ApplicationRole applicationRole);
        public Task<IdentityResult> UpdateUserRole(ApplicationUser applicationUser, string roleName);
        public Task Update(ApplicationUser applicationUser);
        public Task<IdentityResult> ChangePassword(ApplicationUser applicationUser, string password);
    }
}