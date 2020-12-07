using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services.IService;

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
            Console.WriteLine("Da chuyen ");
            var viewModel = _staffService.GetCurrentUser(User);
            return View(viewModel);
        }

        public async Task<IActionResult> Update(
            [Bind("UserName,Email,StaffId,Staff")]
            ApplicationUser viewModel
        )
        {
            ApplicationUser updatedApplicationUser = _staffService.GetCurrentUser(User);
            //update staff info
            updatedApplicationUser.Email = viewModel.Email;
            updatedApplicationUser.Staff.FirstName = viewModel.Staff.FirstName;
            updatedApplicationUser.Staff.LastName = viewModel.Staff.LastName;
            updatedApplicationUser.Staff.Level = viewModel.Staff.Level;

            await _accountService.Update(updatedApplicationUser);

           return RedirectToAction("Me","Staff");
        }
    }
}