using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Models;

namespace TodoList.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new TodoContext(serviceProvider.GetRequiredService<DbContextOptions<TodoContext>>());

            if (context.DSNhanVien.Any())
            {
                // Data has already been seeded
                return;
            }

            /**/ // Seeding ApplicationRoles
            var applicationRoles = new ApplicationRole[]
            {
                new ApplicationRole(ApplicationRole.Roles[0]),
                new ApplicationRole(ApplicationRole.Roles[1]),
            };
            foreach (ApplicationRole role in applicationRoles)
            {
                context.Roles.Add(role);
            }

            /**/ // Seeding First NhanVien
            var nhanVien1 = new NhanVien
            {
                HoTen = "Luu Minh Hoàng",
                Email = "ceriagame@gmail.com",
                Level = Level.NhanVien
            };
            var nhanVien2 = new NhanVien
            {
                HoTen = "Nguyễn Thế Bós",
                Email = "iamtheboss@gmail.com",
                Level = Level.LanhDao
            };
            if (!context.DSNhanVien.Any())
            {
                context.DSNhanVien.AddRange(nhanVien1, nhanVien2);
            }

            context.SaveChanges();

            /**/ // Seeding First ApplicationUsers
            var user1 = new ApplicationUser
            {
                UserName = "hoangluuminh",
                NormalizedUserName = "HOANGLUUMINH",
                NhanVienID = nhanVien1.ID
            };
            var password1 = new PasswordHasher<ApplicationUser>();
            var hashed1 = password1.HashPassword(user1, "123456");
            user1.PasswordHash = hashed1;
            
            var user2 = new ApplicationUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NhanVienID = nhanVien2.ID
            };
            var password2 = new PasswordHasher<ApplicationUser>();
            var hashed2 = password2.HashPassword(user2, "123123");
            user2.PasswordHash = hashed2;
            
            context.Users.AddRange(user1, user2);

            context.SaveChanges();
            
            /**/ // Seeding UserRoles
            context.UserRoles.AddRange(
                new IdentityUserRole<string>
                {
                    UserId = user1.Id,
                    RoleId = applicationRoles[0].Id // NhanVien
                },
                new IdentityUserRole<string>
                {
                    UserId = user2.Id,
                    RoleId = applicationRoles[1].Id    // LanhDao
                }
            );
        }
    }
}