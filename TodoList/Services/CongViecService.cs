using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services.IService;
using TaskStatus = TodoList.Models.TaskStatus;

namespace TodoList.Services
{
    public class CongViecService : ICongViecService
    {
        private readonly TodoContext _context;

        public CongViecService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CongViec>> GetAllCongViecs()
        {
            return await _context.DSCongViec
                .Include(o => o.NhanVien)
                .ToListAsync();
        }

        public async Task<CongViec> GetOneCongViec(int id)
        {
            var congViec = await _context.DSCongViec.FindAsync(id);
            return congViec;
        }

        public async Task<CongViec> CreateCongViec(string name)
        {
            CongViec congViec = new CongViec
            {
                Name = name,
                StartDate = DateTime.Now,
                EndDate = (DateTime.Now).AddDays(7),
                Status = TaskStatus.InProgress,
                Access = TaskAccess.IsPrivate,
            };
            
            // TODO: Replacing with current user
            var nhanVien = await _context.DSNhanVien.FirstOrDefaultAsync();
            congViec.NhanVienID = nhanVien.ID;

            return congViec;
        }

        public void AddCongViec(CongViec congViec)
        {
            _context.Add(congViec);
        }

        public void UpdateCongViec(CongViec congViec)
        {
            _context.Entry(congViec).State = EntityState.Modified;
        }

        public void DeleteCongViec(CongViec congViec)
        {
            _context.Remove(congViec);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}