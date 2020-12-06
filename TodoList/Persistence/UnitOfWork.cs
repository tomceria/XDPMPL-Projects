using Microsoft.AspNetCore.Identity;
using TodoList.Data;
using TodoList.Models;
using TodoList.Persistence.Interfaces;
using TodoList.Persistence.Repositories;

namespace TodoList.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _context;

        public UnitOfWork(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager, TodoContext context)
        {
            Account = new AccountRepository(userManager, signInManager, roleManager);
            TodoTask = new TodoTaskRepository(context);
            Staff = new StaffRepository(context);
            
            _context = context;
        }

        public IAccountRepository Account { get; }
        public ITodoTaskRepository TodoTask { get; }
        public IStaffRepository Staff { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}