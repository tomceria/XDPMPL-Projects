using TechShop_Web.Models;
using System.Collections.Generic;

namespace TechShop_Web.ViewModels
{
    public class ProductIndexVM
    {
        public IEnumerable<Product> Products { get; set; }
    }
}