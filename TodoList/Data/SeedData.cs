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
            var user1 = new ApplicationUser();
            user1.InitUser("admin@gmail.com", staff1);
            var password1 = new PasswordHasher<ApplicationUser>();
            var hashed1 = password1.HashPassword(user1, "123123");
            user1.PasswordHash = hashed1;

            var user2 = new ApplicationUser();
            user2.InitUser("hoanglm@gmail.com", staff2);
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