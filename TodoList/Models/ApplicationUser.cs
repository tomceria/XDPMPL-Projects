using Microsoft.AspNetCore.Identity;

namespace TodoList.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int NhanVienID { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}