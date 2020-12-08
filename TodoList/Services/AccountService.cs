using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TodoList.Models;
using TodoList.Persistence;
using TodoList.Services.IService;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TodoList.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SignInResult> Login(string username, string password)
        {
            var result = await _unitOfWork.Account.LoginAsync(username, password, false, false);
            return result;
        }

        public async Task Logout()
        {
            await _unitOfWork.Account.LogoutAsync();
        }

        public async Task<ApplicationUser> GetUser(string username)
        {
            return await _unitOfWork.Account.GetUserAsync(username);
        }

        public async Task<IdentityResult> CreateAndAddUser(string username, string password, Staff staff)
        {
            var applicationUser = new ApplicationUser();
            applicationUser.InitUser(username, staff);
            var applicationRole = ApplicationRole.Roles[(int) staff.Level];

            var result = await _unitOfWork.Account.CreateUserAsync(applicationUser, password);
            await _unitOfWork.Account.AddUserToRoleAsync(applicationUser, applicationRole);

            if (result == IdentityResult.Success)
            {
                _unitOfWork.Complete();
            }

            return result;
        }

        public async Task<IEnumerable<string>> GetUserRoles(string username)
        {
            var roles = await _unitOfWork.Account.GetUserRolesAsync(username);
            return roles;
        }

        public async Task<bool> IsInRole(ApplicationUser applicationUser, ApplicationRole applicationRole)
        {
            return await _unitOfWork.Account.IsInRoleAsync(applicationUser, applicationRole.Name);
        }

        public async Task<IdentityResult> UpdateUserRole(ApplicationUser applicationUser, string roleName)
        {
            await _unitOfWork.Account.RemoveFromRolesAsync(
                applicationUser, await _unitOfWork.Account.GetUserRolesAsync(applicationUser.UserName)
            );
            return await _unitOfWork.Account.AddUserToRoleAsync(applicationUser, roleName);
        }

        public async Task<IdentityResult> ChangePassword(ApplicationUser applicationUser, string newPassword)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var newPasswordHash = hasher.HashPassword(applicationUser, newPassword);
            applicationUser.PasswordHash = newPasswordHash;

            return await _unitOfWork.Account.UpdateAsync(applicationUser);
        }

        public async Task Update(ApplicationUser applicationUser)
        {
            await _unitOfWork.Account.UpdateAsync(applicationUser);
            _unitOfWork.Complete();
        }
    }
}