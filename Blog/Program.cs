using Blog.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //This is Split the users to allow the Multiple users
            var host = CreateHostBuilder(args).Build();

            try
            {

            var scope = host.Services.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

            context.Database.EnsureCreated();

            var AdminRole = new IdentityRole("Admin");

            if (!context.Roles.Any())
            {
                //Create a new Role...
                roleManager.CreateAsync(AdminRole).GetAwaiter().GetResult();
            }

            if (!context.Users.Any(u=> u.UserName =="Admin"))
            {
                //Create a new User...

                var adminUser = new IdentityUser
                {
                    UserName = "Admin",
                    Email = "Admin@test.com"
                };

                var result = userManager.CreateAsync(adminUser, "Password").GetAwaiter().GetResult(); 
                userManager.AddToRoleAsync(adminUser, AdminRole.Name).GetAwaiter().GetResult(); 
            }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
