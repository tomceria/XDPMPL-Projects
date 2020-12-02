using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TodoList.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        
        public Staff Staff { get; set; }

        public void InitUser(string username, Staff staff)
        {
            UserName = username;
            NormalizedUserName = username.ToUpper();
            Email = username;
            NormalizedEmail = username.ToUpper();
            StaffId = staff.Id;
            Staff = staff;
        }
    }
}