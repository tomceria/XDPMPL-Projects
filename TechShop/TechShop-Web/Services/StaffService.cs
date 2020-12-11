using System.Collections.Generic;
using System.Security.Claims;
using TechShop_Web.Models;
using TechShop_Web.Persistence;
using TechShop_Web.Services.IService;

namespace TechShop_Web.Services
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

        public Staff GetOneStaff(int id)
        {
            return _unitOfWork.Staff.GetBy(id);
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _unitOfWork.Staff.GetAllUsers();
        }

        public ApplicationUser GetUser(int staffId)
        {
            return _unitOfWork.Staff.GetUserWithStaff(staffId);
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

        public void UpdateStaff(Staff staff)
        {
            /*
             * Preserve Level
             */
            var originalStaff = _unitOfWork.Staff.GetBy(staff.Id);
            _unitOfWork.Staff.Detach(originalStaff);
            staff.Level = originalStaff.Level;
            
            _unitOfWork.Staff.Update(staff);
            _unitOfWork.Complete();
        }

        public void RemoveStaff(Staff staff)
        {
            _unitOfWork.Staff.Remove(staff);
            _unitOfWork.Complete();
        }
    }
}