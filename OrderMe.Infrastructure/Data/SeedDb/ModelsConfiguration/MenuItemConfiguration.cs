using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Infrastructure.Data.SeedDb.ModelsConfiguration
{
    internal class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {

        }
    }
   
}
