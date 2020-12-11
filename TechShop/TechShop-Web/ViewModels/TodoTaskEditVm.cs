using System.Collections.Generic;
using TechShop_Web.Models;

namespace TechShop_Web.ViewModels
{
    public class TodoTaskEditVm
    {
        public TodoTask TodoTask { get; set; }
        public List<Staff> Staffs { get; set; }
        public int[] TodoTaskPartnerIds { get; set; }
        
        public Staff CurrentStaff { get; set; }
    }
}