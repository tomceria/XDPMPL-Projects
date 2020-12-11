using Microsoft.AspNetCore.Mvc;
using TechShop_Web.Services.IService;
using TechShop_Web.ViewModels;

namespace TechShop_Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IAccountService _accountService;

        public StaffController(IStaffService staffService, IAccountService accountService)
        {
            _staffService = staffService;
            _accountService = accountService;
        }

        public IActionResult Me()
        {
            var staff = _staffService.GetCurrentUser(User).Staff;
            var viewModel = new AccountMeVm
            {
                Staff = staff
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Me([Bind("Staff")] AccountMeVm viewModel)
        {
            var staff = viewModel.Staff;
            
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _staffService.UpdateStaff(staff);

            return RedirectToAction("Me");
        }
    }
}