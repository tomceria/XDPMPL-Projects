using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services.IService;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TodoList.Services
{
    public class AccountService : IAccountService
    {
        private readonly TodoContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountService(TodoContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        
        public async Task<SignInResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ApplicationUser> GetCurrentUser(ClaimsPrincipal user)
        {
            var userId = _userManager.GetUserId(user);
            var applicationUser = await _context.Users
                .Include(o => o.Staff)
                .Where(o => o.Id == userId)
                .FirstAsync();
            
            return applicationUser;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _context.Users.Include(o => o.Staff).ToListAsync();
        }

        public async Task<IdentityResult> CreateUser(string username, string password, Staff staff)
        {
            var applicationUser = new ApplicationUser();
            applicationUser.InitUser(username, staff);
            var result = await _userManager.CreateAsync(applicationUser, password);
            return result;
        }

        public async Task<IEnumerable<string>> GetUserRoles(string username)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(username);
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }

        public async Task<bool> IsInRole(ApplicationUser applicationUser, ApplicationRole applicationRole)
        {
            return await _userManager.IsInRoleAsync(applicationUser, applicationRole.Name);
        }

        public async Task<IdentityResult> AddUserToRole(ApplicationUser applicationUser, ApplicationRole applicationRole)
        {
            return await _userManager.AddToRoleAsync(applicationUser, applicationRole.Name);
        }

        public async Task<IdentityResult> ChangePassword(ApplicationUser applicationUser, string newPassword)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var newPasswordHash = hasher.HashPassword(applicationUser, newPassword);
            applicationUser.PasswordHash = newPasswordHash;
            
            return await _userManager.UpdateAsync(applicationUser);
        }
        
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}