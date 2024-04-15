using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Infrastructure.Data.SeedDb.ModelsConfiguration
{
    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder
                 .HasOne(c => c.User)
                 .WithMany()
                 .HasForeignKey(c => c.UserId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();
            builder.HasData(data.Cart);
        }
    }
}
