using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.ViewModels
{
    public class HomeIndexVm
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Combo> Combos { get; set; }
    }
}