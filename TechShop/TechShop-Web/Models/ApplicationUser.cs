using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TechShop_Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        
        public Customer Customer { get; set; }

        public void InitUser(string username, Customer customer)
        {
            UserName = username;
            NormalizedUserName = username.ToUpper();
            Email = username;
            NormalizedEmail = username.ToUpper();
            CustomerId = customer.Id;
            Customer = customer;
        }
    }
}