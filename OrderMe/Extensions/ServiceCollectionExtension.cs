using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderMe.Core.Contracts;
using OrderMe.Core.Services;
using OrderMe.Infrastructure.Data;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IGarageService, GarageService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IMenuItemService, MenuItemService>();
            services.AddScoped<IOrderRideService, OrderRideService>();
           // services.AddScoped<IDriverService>(); // does not have a service (used only as a basic interface inside the user controller)

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();



            return services;
        }
    }
}
