using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}