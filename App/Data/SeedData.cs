using Microsoft.EntityFrameworkCore;
using App.Models;
using App.Data;
using Microsoft.AspNetCore.Identity;

namespace Api.Data
{
    public static class SeedData
    {
        public static async Task InitializeDBAsync(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Check if Users table is empty, then seed data
            if (!await context.Users.AnyAsync())
            {
                await SeedUserAndRolesAsync(userManager, roleManager);
            }
        }

        private static async Task SeedUserAndRolesAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
            if (!adminRoleExists)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var adminEmail = "admin@admin.com";
            var adminPassword = "Abc123!";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    NormalizedEmail = adminEmail,
                };

                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
