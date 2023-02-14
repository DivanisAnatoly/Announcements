using Announcements.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcements.Infrastructure.DataAccess.EntitiesConfiguration
{
    class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);

            builder.HasData(
                new Region { ID = 1, Name = "Moscow" }
                );
        }

    }
}
