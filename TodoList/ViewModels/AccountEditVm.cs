using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoList.ViewModels
{
    public class AccountEditVm
    {
        [Required]
        public int StaffId { get; set; }
        
        [Required]
        [DisplayName("Chức vụ")]
        public int RoleId { get; set; }
    }
}