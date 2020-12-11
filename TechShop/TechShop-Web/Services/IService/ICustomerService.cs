using System.Collections.Generic;
using System.Security.Claims;
using TechShop_Web.Models;

namespace TechShop_Web.Services.IService
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetOneCustomer(int id);
        IEnumerable<ApplicationUser> GetAllUsers();
        ApplicationUser GetUser(int staffId);
        ApplicationUser GetCurrentUser(ClaimsPrincipal user);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
    }
}