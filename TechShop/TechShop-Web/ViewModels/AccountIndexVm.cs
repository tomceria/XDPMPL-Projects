using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.ViewModels
{
    public class AccountIndexVm
    {
        public IEnumerable<ApplicationUser> Accounts { get; set; }
    }
}
