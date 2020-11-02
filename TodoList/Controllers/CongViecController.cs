using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class CongViecController : Controller
    {
        private readonly TodoContext _context;

        public CongViecController(TodoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.DSCongViec.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CongViec congViec = await _context.DSCongViec.FindAsync(id);
            if (congViec == null)
            {
                return NotFound();
            }

            return View(congViec);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        {
            // TODO: Must be authorized to run this action

            CongViec congViec = new CongViec
            {
                Name = name,
                StartDate = DateTime.Now,
                EndDate = (DateTime.Now).AddDays(7),
                TrangThai = Status.inProgress,
                Privacy = Access.isPrivate,
            };

            // TODO: Replacing with current user
            var nhanVien = await _context.DSNhanVien.FirstOrDefaultAsync();
            congViec.NhanVienID = nhanVien.ID;

            await _context.AddAsync(congViec);
            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", new {id = congViec.ID});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StartDate,EndDate,TrangThai,Privacy,NhanVienID")]
            CongViec congViec)
        {
            if (id != congViec.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(congViec);
            
            _context.Update(congViec);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            CongViec congViec = await _context.DSCongViec.FindAsync(id);
            if (congViec == null)
            {
                return NotFound();
            }
            
            if (!ModelState.IsValid) return RedirectToAction("Edit", new { id = id });
            
            _context.Remove(congViec);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
    }
}