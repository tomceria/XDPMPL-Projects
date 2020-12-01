using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Services.IService;
using TodoList.ViewModels;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TodoList.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize(Roles = "Leader")]
        public IActionResult Index()
        {
            return View();
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
                viewModel.FormResults = new List<FormResult>
                {
                    new FormResult(AlertType.DANGER, "Tên tài khoản hoặc mật khẩu không đúng!")
                };
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
            return RedirectToAction("Index", "Home");
        }
    }
}