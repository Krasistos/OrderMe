using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.ApplyConfiguration for everything should be here


            //// Ensure only one agency record - singleton
            //builder.Entity<OrderMeAgency>()
            //    .HasIndex(a => a.SingletonId)  
            //    .IsUnique();                   

            base.OnModelCreating(builder);
        }

        //Db set with only one record - singleton 
        public DbSet<OrderMeAgency> OrderMeAgency { get; set; } = null!;
        

        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<FoodOrder> FoodOrders { get; set; } = null!;
        public DbSet<Garage> Garages { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<RiderOrder> RideOrders { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
    }
}
