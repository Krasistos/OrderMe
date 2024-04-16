using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderMe.Infrastructure.Data.Models;
using System.Reflection.Emit;

namespace OrderMe.Infrastructure.Data.SeedDb.ModelsConfiguration
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {

            builder
              .Property(v => v.ImageData)
              .IsRequired()
              .HasColumnType("varbinary(max)");

            var data = new SeedData();

            builder.HasData(data.Vehicle);
        }
    }
}
