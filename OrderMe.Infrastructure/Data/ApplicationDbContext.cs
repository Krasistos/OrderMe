using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderMe.Infrastructure.Data.Models;
using OrderMe.Infrastructure.Data.SeedDb;
using OrderMe.Infrastructure.Data.SeedDb.ModelsConfiguration;

namespace OrderMe.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Db set with only one record - singleton 
        public DbSet<OrderMeAgency> OrderMeAgency { get; set; } = null!;


        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<FoodOrder> FoodOrders { get; set; } = null!;
        public DbSet<Garage> Garages { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<RideOrder> RideOrders { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Apply all configurations
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new DriverConfiguration());
            builder.ApplyConfiguration(new FoodOrderConfiguration());
            builder.ApplyConfiguration(new GarageConfiguration());
            builder.ApplyConfiguration(new MenuItemConfiguration());
            builder.ApplyConfiguration(new OrderMeAgencyConfiguration());
            builder.ApplyConfiguration(new RestaurantConfiguration());
            builder.ApplyConfiguration(new RideOrderConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());

            base.OnModelCreating(builder); // Call base method
        }
    }
}
