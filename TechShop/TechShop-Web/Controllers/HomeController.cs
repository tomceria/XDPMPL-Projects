using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechShop_Web.Models;
using TechShop_Web.Services.IService;
using TechShop_Web.ViewModels;

namespace TechShop_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IComboService _comboService;
        
        public HomeController(ILogger<HomeController> logger, IProductService productService, IComboService comboService)
        {
            _logger = logger;
            _productService = productService;
            _comboService = comboService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            var combos = _comboService.GetAllCombos();
            
            /*
             * Constructs ViewModel
             */
            var viewModel = new HomeIndexVm()
            {
                Products = products,
                Combos = combos
            };
            
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
