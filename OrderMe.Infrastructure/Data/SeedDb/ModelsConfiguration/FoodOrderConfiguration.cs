using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderMe.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
