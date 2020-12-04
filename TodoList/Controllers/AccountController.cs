using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoList.Services.IService;
using TodoList.ViewModels;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TodoList.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IStaffService _staffService;

        public AccountController(IAccountService accountService, IStaffService staffService)
        {
            _accountService = accountService;
            _staffService = staffService;
        }

        [Authorize(Roles = "Leader")]
        public async Task<IActionResult> Index()
        {   
            var accounts = await _accountService.GetAllUsers();

            var viewModel = new AccountIndexVm
            {
                Accounts = accounts
            };
            return View(viewModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Username,Password")] AccountLoginVm viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var (username, password) = viewModel;
            SignInResult result = await _accountService.Login(username, password);

            if (result == SignInResult.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (result == SignInResult.Failed)
            {
                ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không đúng!");
                return View(viewModel);
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Leader")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(
            [Bind("Username,Password,Password2,Staff")]
            AccountRegisterVm viewModel
        )
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var (username, password, staff) = viewModel;

            /*
             * Main actions
             */
            _staffService.AddStaff(staff);
            await _staffService.Save();    // Must be saved to have generated ID
            var result = await _accountService.CreateUser(username, password, staff);

            if (result != IdentityResult.Success)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                
                /*
                 * Deleting newly added Staff if Registering failed
                 */
                await _accountService.Save();
                _staffService.RemoveStaff(staff);
                await _staffService.Save();

                return View(viewModel);
            }
            
            return RedirectToAction("Index", "Account");
        }
    }
}