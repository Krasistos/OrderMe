using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Infrastructure.Data.SeedDb.ModelsConfiguration
{
    internal class FoodOrderConfiguration : IEntityTypeConfiguration<FoodOrder>
    {
        public void Configure(EntityTypeBuilder<FoodOrder> builder)
        {
            builder
                .HasOne(fo => fo.Cart)
                .WithMany()
                .HasForeignKey(fo => fo.CartId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fo => fo.Driver)
                .WithMany()
                .HasForeignKey(fo => fo.DriverId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fo => fo.Vehicle)
                .WithMany()
                .HasForeignKey(fo => fo.VehicleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fo => fo.Restaurant)
                .WithMany()
                .HasForeignKey(fo => fo.RestaurantId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fo => fo.User)
                .WithMany()
                .HasForeignKey(fo => fo.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
