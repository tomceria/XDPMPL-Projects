using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly TodoContext _context;

        public NhanVienController(TodoContext context)
        {
            _context = context;
        }
    }
}