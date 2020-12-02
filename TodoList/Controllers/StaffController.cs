using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class StaffController : Controller
    {
        private readonly TodoContext _context;

        public StaffController(TodoContext context)
        {
            _context = context;
        }

        public IActionResult Me()
        {
            return View();
        }
    }
}