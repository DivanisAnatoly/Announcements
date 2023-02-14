using Announcements.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcements.Infrastructure.DataAccess.EntitiesConfiguration
{
    class AnnouncementFilesConfiguration : IEntityTypeConfiguration<AnnouncementFile>
    {
        public void Configure(EntityTypeBuilder<AnnouncementFile> builder)
        {
            builder.HasKey(af => af.ID);

            builder.Property(af => af.AnnouncementID).IsRequired();
            builder.Property(af => af.Name).IsRequired().HasMaxLength(100);
        }

    }
}