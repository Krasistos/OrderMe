using Microsoft.AspNetCore.Identity;
using OrderMe.Infrastructure.Data.Models;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure admin role exists
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Ensure admin user exists and assign admin role
            var adminUser = await userManager.FindByEmailAsync("admin@mail.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser { UserName = "admin@mail.com", Email = "admin@mail.com" };
                await userManager.CreateAsync(adminUser, "Admin@123"); // Set admin password
            }

            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            Console.WriteLine("Admin role and user created successfully.");
        }
    }
}
