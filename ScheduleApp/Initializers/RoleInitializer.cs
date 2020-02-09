using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ScheduleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Initializers
{
    public class RoleInitializer
    {
        private readonly ILogger<RoleInitializer> _logger;

        public RoleInitializer(ILogger<RoleInitializer> logger)
        {
            _logger = logger;
        }

        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string name = "Admin";
            string surname = "Admin";
            string password = "qweQWE1!";
            if (await roleManager.FindByNameAsync("Адміністратор") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Адміністратор"));
            }
            if (await roleManager.FindByNameAsync("Викладач") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Викладач"));
            }
            if (await roleManager.FindByNameAsync("Студент") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Студент"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User {
                    Email = adminEmail,
                    UserName = adminEmail,
                    FirstName = name,
                    LastName = surname,
                    EmailConfirmed = true
                };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    IdentityResult roleAddingResult = await userManager.AddToRoleAsync(admin, "Адміністратор");

                    foreach (var error in roleAddingResult.Errors)
                    {
                        Console.WriteLine(error);
                    }
                }
            }
        }
    }
}
