using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Models;

namespace TodoList.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new TodoContext(serviceProvider.GetRequiredService<DbContextOptions<TodoContext>>());

            if (!context.DSNhanVien.Any())
            {
                context.DSNhanVien.AddRange(
                    new NhanVien
                    {
                        HoTen = "Luu Minh Hoàng",
                        Email = "ceriagame@gmail.com",
                        Level = Level.NhanVien
                    }
                );
            }


            context.SaveChanges();
        }
    }
}