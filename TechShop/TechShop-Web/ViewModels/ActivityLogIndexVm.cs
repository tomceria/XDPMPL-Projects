using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.ViewModels
{
    public class ActivityLogIndexVm
    {
        public IEnumerable<ActivityLog> ActivityLogs { get; set; }
    }
}