using Microsoft.AspNetCore.Identity;
using TechShop_Web.Data;
using TechShop_Web.Models;
using TechShop_Web.Persistence.Interfaces;
using TechShop_Web.Persistence.Repositories;

namespace TechShop_Web.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _context;

        public UnitOfWork(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager, ShopContext context)
        {
            Account = new AccountRepository(userManager, signInManager, roleManager);
            Customer = new CustomerRepository(context);
            
            _context = context;
        }

        public IAccountRepository Account { get; }
        public ICustomerRepository Customer { get; }

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