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
            ApplicationUser applicationUser = _staffService.GetCurrentUser(User);
            var viewModel = new AccountInfoVm
            {
                ApplicationUser = applicationUser,
                Password = ""
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Update(
            [Bind("ApplicationUser,Password")]
            AccountInfoVm viewModel
        )
        {
            var (applicationUser, password) = viewModel;
            ApplicationUser updatedApplicationUser = _staffService.GetCurrentUser(User);
            //update staff info
            updatedApplicationUser.Email = applicationUser.Email;
            updatedApplicationUser.Staff.FirstName = applicationUser.Staff.FirstName;
            updatedApplicationUser.Staff.LastName = applicationUser.Staff.LastName;
            updatedApplicationUser.Staff.Level = applicationUser.Staff.Level;

            await _accountService.Update(updatedApplicationUser);
            //Change password
            if (password != null)
            {
                await _accountService.ChangePassword(applicationUser, password);// Not save
            }    

           return RedirectToAction("Me","Staff");
        }
    }
}