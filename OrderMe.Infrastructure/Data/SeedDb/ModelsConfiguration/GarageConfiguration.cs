using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Infrastructure.Data.SeedDb.ModelsConfiguration
{
    internal class GarageConfiguration : IEntityTypeConfiguration<Garage>
    {
        public void Configure(EntityTypeBuilder<Garage> builder)
        {
            builder
                .HasOne(g => g.User)
                .WithMany()
                .HasForeignKey(g => g.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
