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
    }
}