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

            if (context.Staffs.Any())
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

            /**/ // Seeding First Staffs
            var staff1 = new Staff
            {
                FirstName = "Bós",
                LastName = "Nguyễn Thế",
                Level = Level.Leader
            };
            var staff2 = new Staff
            {
                FirstName = "Hoàng",
                LastName = "Lưu Minh",
                Level = Level.Member
            };
            if (!context.Staffs.Any())
            {
                context.Staffs.AddRange(staff1, staff2);
            }

            context.SaveChanges();

            /**/ // Seeding First ApplicationUsers
            var user1 = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                StaffId = staff1.Id
            };
            var password1 = new PasswordHasher<ApplicationUser>();
            var hashed1 = password1.HashPassword(user1, "123123");
            user1.PasswordHash = hashed1;
            
            var user2 = new ApplicationUser
            {
                UserName = "ceriagame@gmail.com",
                NormalizedUserName = "CERIAGAME@GMAIL.COM",
                Email = "ceriagame@gmail.com",
                NormalizedEmail = "CERIAGAME@GMAIL.COM",
                StaffId = staff2.Id
            };
            var password2 = new PasswordHasher<ApplicationUser>();
            var hashed2 = password2.HashPassword(user2, "123456");
            user2.PasswordHash = hashed2;
            
            context.Users.AddRange(user1, user2);

            context.SaveChanges();
            
            /**/ // Seeding UserRoles
            context.UserRoles.AddRange(
                new IdentityUserRole<string>
                {
                    UserId = user1.Id,
                    RoleId = applicationRoles[1].Id // Leader
                },
                new IdentityUserRole<string>
                {
                    UserId = user2.Id,
                    RoleId = applicationRoles[0].Id    // Member
                }
            );
            
            context.SaveChanges();
        }
    }
}