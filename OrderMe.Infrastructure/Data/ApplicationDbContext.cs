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
            base.OnModelCreating(builder); // Call base method first

            // Configure RideOrder entity
            builder.Entity<RideOrder>()
                .HasOne(ro => ro.Driver)
                .WithMany()
                .HasForeignKey(ro => ro.DriverId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RideOrder>()
                .HasOne(ro => ro.Vehicle)
                .WithMany()
                .HasForeignKey(ro => ro.VehicleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Configure FoodOrder entity
            builder.Entity<FoodOrder>()
                .HasOne(fo => fo.Cart)
                .WithMany()
                .HasForeignKey(fo => fo.CartId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FoodOrder>()
                .HasOne(fo => fo.Driver)
                .WithMany()
                .HasForeignKey(fo => fo.DriverId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FoodOrder>()
                .HasOne(fo => fo.Vehicle)
                .WithMany()
                .HasForeignKey(fo => fo.VehicleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FoodOrder>()
                .HasOne(fo => fo.Restaurant)
                .WithMany()
                .HasForeignKey(fo => fo.RestaurantId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FoodOrder>()
                .HasOne(fo => fo.User)
                .WithMany()
                .HasForeignKey(fo => fo.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Restaurant entity
            builder.Entity<Restaurant>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Garage entity
            builder.Entity<Garage>()
                .HasOne(g => g.User)
                .WithMany()
                .HasForeignKey(g => g.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Driver entity
            builder.Entity<Driver>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Cart entity
            builder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
