using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TodoList.Models
{
    public class ApplicationRole : IdentityRole
    {
        public static Dictionary<string, ApplicationRole> Roles = new Dictionary<string, ApplicationRole>
        {
            { "NhanVien", new ApplicationRole("NhanVien") },
            { "LanhDao", new ApplicationRole("LanhDao") }
        };

        private ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}