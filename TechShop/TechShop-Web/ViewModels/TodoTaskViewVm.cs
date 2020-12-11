using TechShop_Web.Models;

namespace TechShop_Web.ViewModels
{
    public class TodoTaskViewVm
    {
        public TodoTask TodoTask { get; set; }

        public bool IsAssignedToMe { get; set; }
        public bool IsCreatedByMe { get; set; }
        
        public Staff CurrentStaff { get; set; }
    }
}