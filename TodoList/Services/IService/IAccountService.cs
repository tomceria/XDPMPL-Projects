using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TodoList.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TodoList.Services.IService
{
    public interface IAccountService
    {

        public Task<SignInResult> Login(string username, string password);
        public Task Logout();
        public Task<IdentityResult> CreateUser(ApplicationUser applicationUser, string password);
        public Task<IEnumerable<string>> GetUserRoles(string username);
        public Task<bool> IsInRole(ApplicationUser applicationUser, ApplicationRole applicationRole);
        public Task<IdentityResult> AddUserToRole(ApplicationUser applicationUser, ApplicationRole applicationRole);
        public Task<IdentityResult> ChangePassword(ApplicationUser applicationUser, string password);
    }
}