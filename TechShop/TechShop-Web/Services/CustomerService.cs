using System.Collections.Generic;
using System.Security.Claims;
using TechShop_Web.Models;
using TechShop_Web.Persistence;
using TechShop_Web.Services.IService;

namespace TechShop_Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _unitOfWork.Customer.GetAll();
        }

        public Customer GetOneCustomer(int id)
        {
            return _unitOfWork.Customer.GetBy(id);
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _unitOfWork.Customer.GetAllUsers();
        }

        public ApplicationUser GetUser(int staffId)
        {
            return _unitOfWork.Customer.GetUserWithStaff(staffId);
        }

        public ApplicationUser GetCurrentUser(ClaimsPrincipal user)
        {
            return _unitOfWork.Customer.GetUserWithStaff(user.Identity.Name);
        }

        public void AddCustomer(Customer customer)
        {
            _unitOfWork.Customer.Add(customer);
            _unitOfWork.Complete();
        }

        public void UpdateCustomer(Customer customer)
        {
            _unitOfWork.Customer.Update(customer);
            _unitOfWork.Complete();
        }

        public void RemoveCustomer(Customer customer)
        {
            _unitOfWork.Customer.Remove(customer);
            _unitOfWork.Complete();
        }
    }
}