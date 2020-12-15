using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TechShop_Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        
        public Customer Customer { get; set; }

        public void InitUser(string username, Customer customer)
        {
            UserName = username;
            NormalizedUserName = username.ToUpper();
            Email = username;
            NormalizedEmail = username.ToUpper();
            StaffId = customer.Id;
            Customer = customer;
        }
    }
}