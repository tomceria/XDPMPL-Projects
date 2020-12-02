using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class AccountIndexVm
    {
        public IEnumerable<ApplicationUser> Accounts { get; set; }
    }
}
