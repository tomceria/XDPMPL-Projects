using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services.IService;

namespace TodoList.Services
{
    public class StaffService : IStaffService
    {
        private readonly TodoContext _context;

        public StaffService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Staff>> GetAllStaffs()
        {
            return await _context.Staffs.ToListAsync();
        }

        public void AddStaff(Staff staff)
        {
            _context.Entry(staff).State = EntityState.Added;
        }

        public void RemoveStaff(Staff staff)
        {
            _context.Remove(staff);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}