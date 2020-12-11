using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TechShop_Web.Models;

namespace TechShop_Web.ViewModels
{
    public class AccountEditVm
    {
        public ApplicationUser ApplicationUser { get; set; }
        
        [Required]
        [DisplayName("Tài khoản")]
        public int StaffId { get; set; }
        
        [Required]
        [DisplayName("Chức vụ")]
        public int RoleId { get; set; }
    }
}