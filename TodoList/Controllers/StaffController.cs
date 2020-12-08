using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services.IService;
using TodoList.ViewModels;

namespace TodoList.Controllers
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
        public IActionResult Me([Bind("Staff,Password")] AccountMeVm viewModel)
        {
            var staff = viewModel.Staff;
            
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _staffService.UpdateStaff(staff);

            // //Change password
            // if (password != null)
            // {
            //     await _accountService.ChangePassword(applicationUser, password);// Not save
            // }    

            return RedirectToAction("Me");
        }
    }
}