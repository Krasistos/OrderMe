using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Infrastructure.Data.SeedDb.ModelsConfiguration
{
    internal class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder
               .Property(v => v.ImageData)
               .IsRequired()
               .HasColumnType("varbinary(max)");

            var data = new SeedData();
            builder.HasData(data.MenuItem);
        }
    }
   
}
