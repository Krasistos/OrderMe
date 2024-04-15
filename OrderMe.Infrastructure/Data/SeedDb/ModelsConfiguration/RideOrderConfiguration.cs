using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Infrastructure.Data.SeedDb.ModelsConfiguration
{
    internal class RideOrderConfiguration : IEntityTypeConfiguration<RideOrder>
    {
        public void Configure(EntityTypeBuilder<RideOrder> builder)
        {
            builder
               .HasOne(ro => ro.Driver)
               .WithMany()
               .HasForeignKey(ro => ro.DriverId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ro => ro.Vehicle)
                .WithMany()
                .HasForeignKey(ro => ro.VehicleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
