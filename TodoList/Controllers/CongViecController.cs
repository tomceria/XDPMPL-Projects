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
            if (id == null)    // TODO: Check with database
            {
                return NotFound();
            }
            
            CongViec congViec = new CongViec();
            congViec.ID = (int) id;
            congViec.Name = "Hello there!!!";
            congViec.StartDate = DateTime.Now;

            return View(congViec);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StartDate,EndDate,TrangThai,Privacy")] CongViec congViec)
        {
            if (id != congViec.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(congViec);
            try
            {
                _context.Update(congViec);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
                // if (!CongViecExists(congViec.ID))
                // {
                //     return NotFound();
                // }
                // else
                // {
                //     throw;
                // }
            }
            return RedirectToAction("Index");
        }
    }
}