using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Persistence;
using TodoList.Persistence.Interfaces;
using TodoList.Persistence.Repositories;
using TodoList.Services;
using TodoList.Services.IService;

namespace TodoList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            /**/ // Registering Database Connection
            services.AddDbContext<TodoContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("HoangTodoContext")
                )
            );
            
            /**/ // Registering Identity Service
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddRoleManager<RoleManager<ApplicationRole>>()
                .AddEntityFrameworkStores<TodoContext>()
                .AddDefaultTokenProviders(); 
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LoginPath = "/Account/Login";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
            }); 

            /**/ // Injecting Business Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            /**/ // Injecting Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            /**/ // Injecting Business Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITodoTaskService, TodoTaskService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IReportService, ReportService>();
        }

        /**/ // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}