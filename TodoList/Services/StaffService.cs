using System.Collections.Generic;
using System.Security.Claims;
using TodoList.Models;
using TodoList.Persistence;
using TodoList.Services.IService;

namespace TodoList.Services
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Staff> GetAllStaffs()
        {
            return _unitOfWork.Staff.GetAll();
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _unitOfWork.Staff.GetAllUsers();
        }

        public ApplicationUser GetCurrentUser(ClaimsPrincipal user)
        {
            return _unitOfWork.Staff.GetUserWithStaff(user.Identity.Name);
        }

        public void AddStaff(Staff staff)
        {
            _unitOfWork.Staff.Add(staff);
            _unitOfWork.Complete();
        }

        public void RemoveStaff(Staff staff)
        {
            _unitOfWork.Staff.Remove(staff);
            _unitOfWork.Complete();
        }
    }
}