using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechShop_Web.Models;
using TechShop_Web.Services.IService;
using TechShop_Web.ViewModels;

namespace TechShop_Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var viewModel = new ProductIndexVM
            {
                Products = _productService.GetAllProducts()
            };
            return View(viewModel);
        }

        public IActionResult Show(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetOneProduct((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
