using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TechShop_Web.Models
{
    public sealed class ApplicationRole : IdentityRole
    {
        public static readonly List<string> Roles = new List<string>
        {
            "Member", "Leader"
        };
        
        public ApplicationRole() {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
            NormalizedName = roleName.ToUpper();
        }
    }
}