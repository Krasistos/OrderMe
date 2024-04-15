using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Infrastructure.Data.SeedDb.ModelsConfiguration
{
    internal class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder
               .HasOne(r => r.User)
               .WithMany()
               .HasForeignKey(r => r.UserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();
            builder.HasData(data.Restaurant);
        }
    }
}
