using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
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

        public void AddStaff(Staff staff)
        {
            _unitOfWork.Staff.Add(staff);
        }

        public void RemoveStaff(Staff staff)
        {
            _unitOfWork.Staff.Remove(staff);
        }
    }
}