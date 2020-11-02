using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data
{
    public class TodoContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<NhanVien> DSNhanVien { get; set; }
        public DbSet<CongViec> DSCongViec { get; set; }
        public DbSet<NguoiLamChung> DSNguoiLamChung { get; set; }
        public DbSet<BinhLuan> DSBinhLuan { get; set; }
    }
}