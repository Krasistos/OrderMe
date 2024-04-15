using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Infrastructure.Data.SeedDb.ModelsConfiguration
{
    internal class OrderMeAgencyConfiguration : IEntityTypeConfiguration<OrderMeAgency>
    {
        public void Configure(EntityTypeBuilder<OrderMeAgency> builder)
        {
            var data = new SeedData();
            builder.HasData(data.OrderMeAgency);
        }
    }
}
