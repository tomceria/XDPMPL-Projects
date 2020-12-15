using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechShop_Web.Services.IService;
using TechShop_Web.ViewModels;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TechShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;

        public AccountController(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(
            [Bind("Username,Password,Password2,Customer")]
            AccountRegisterVm viewModel
        )
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var (username, password, customer) = viewModel;

            _customerService.AddCustomer(customer); // Must be saved to have generated ID
            var result = await _accountService.CreateAndAddUser(username, password, customer);

            if (result != IdentityResult.Success)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                _customerService.RemoveCustomer(customer); // Deleting newly added Customer if Registering failed

                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}