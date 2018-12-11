using DAL.RepositoryPattern.IdentityEntities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class IdentitySeedData
    {
        private const string adminUser = "InitialAdmin";
        private const string adminPassword = "$Hovo123";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<User> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .GetRequiredService<RoleManager<IdentityRole>>();

            User user = await userManager.FindByIdAsync(adminUser);
            if(!await roleManager.RoleExistsAsync("Admin"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);
            }
            if (user == null)
            {
                user = new User { Name = "Hovo", Surname = "Guloyan",
                    UserName = "Hovo@gmail.com", SecurityStamp = Guid.NewGuid().ToString() };
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, "Admin");
                
            }
        }

    }
}
