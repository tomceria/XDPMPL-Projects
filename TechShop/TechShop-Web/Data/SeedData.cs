using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechShop_Web.Models;

namespace TechShop_Web.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ShopContext(serviceProvider.GetRequiredService<DbContextOptions<ShopContext>>());

            if (context.Customers.Any())
            {
                // Data has already been seeded
                return;
            }

            /**/ // Seeding ApplicationRoles
            var applicationRoles = new[]
            {
                new ApplicationRole(ApplicationRole.Roles[0])
            };
            foreach (ApplicationRole role in applicationRoles)
            {
                context.Roles.Add(role);
            }

            /**/ // Seeding First Customers
            var staff1 = new Customer
            {
                FirstName = "Cà",
                LastName = "Ra Ra",
                Email = "caracara@gmail.com",
                PhoneNumber = "0909000999",
                DOB = DateTime.Now.AddYears(-20),
                Address = "1 Nhà Đẹp, P10, Q100"
            };
            var staff2 = new Customer
            {
                FirstName = "Hoàng",
                LastName = "Lưu Minh",
                Email = "hoanglm@gmail.com",
                PhoneNumber = "0900999000",
                DOB = new DateTime(1999, 10, 22),
                Address = "100 Forever, P9, Q10"
            };
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(staff1, staff2);
            }

            context.SaveChanges();

            /**/ // Seeding First ApplicationUsers
            var user1 = new ApplicationUser();
            user1.InitUser("caracara", staff1);
            var password1 = new PasswordHasher<ApplicationUser>();
            var hashed1 = password1.HashPassword(user1, "123123");
            user1.PasswordHash = hashed1;

            var user2 = new ApplicationUser();
            user2.InitUser("hoanglm", staff2);
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
                    RoleId = applicationRoles[0].Id
                },
                new IdentityUserRole<string>
                {
                    UserId = user2.Id,
                    RoleId = applicationRoles[0].Id
                }
            );
            
            context.SaveChanges();
        }
    }
}