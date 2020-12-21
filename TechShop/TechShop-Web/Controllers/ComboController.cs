using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechShop_Web.Models;
using TechShop_Web.Services.IService;
using TechShop_Web.ViewModels;

namespace TechShop_Web.Controllers
{
    public class ComboController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IComboService _comboService;

        public ComboController(ILogger<HomeController> logger, IComboService comboService)
        {
            _logger = logger;
            _comboService = comboService;
        }

        public IActionResult Index()
        {
            var viewModel = new ComboIndexVm
            {
                Combos = _comboService.GetAllCombos()
            };
            return View(viewModel);
        }

        public IActionResult Show(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combo = _comboService.GetOneCombo((int)id);
            if (combo == null)
            {
                return NotFound();
            }

            return View(combo);
        }
    }
}
