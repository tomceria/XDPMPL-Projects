using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TodoList.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        
        public Staff Staff { get; set; }
    }
}