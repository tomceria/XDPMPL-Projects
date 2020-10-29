using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
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

            return View(congViec);
        }
    }
}