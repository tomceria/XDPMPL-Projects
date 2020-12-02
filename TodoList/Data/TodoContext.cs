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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TodoTaskPartner>()
                .HasKey(a => new { a.TodoTaskId, a.StaffId });
            builder.Entity<TodoTaskPartner>()
                .HasOne(o => o.TodoTask)
                .WithMany(o => o.TodoTaskPartners)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<TodoTaskPartner>()
                .HasOne(o => o.Staff)
                .WithMany(o => o.TodoTaskPartners)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<TodoTask>()
                .HasOne(o => o.CreatedBy)
                .WithMany(o => o.CreatedTodoTasks)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Comment>()
                .HasOne(o => o.Staff)
                .WithMany(o => o.Comments)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<TodoTaskPartner> TodoTaskPartners { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public object Comment { get; internal set; }
    }
}