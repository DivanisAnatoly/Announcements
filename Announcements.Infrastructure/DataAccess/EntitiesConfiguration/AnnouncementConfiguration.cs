using Announcements.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcements.Infrastructure.DataAccess.EntitiesConfiguration
{
    class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.Title).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Description).IsRequired().HasMaxLength(3000); 
            builder.Property(a => a.RegionID).IsRequired(false);
            builder.Property(a => a.Price).IsRequired(false);
            builder.Property(a => a.CategoryID).IsRequired(false);
            builder.Property(a => a.OwnerID).IsRequired();
            builder.Property(a => a.PublishDate).IsRequired();

            builder
                .HasOne(a => a.Region)
                    .WithMany()
                    .HasForeignKey(a => a.RegionID)
                    .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(a => a.Category)
                    .WithMany()
                    .HasForeignKey(a => a.CategoryID)
                    .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(a => a.Owner)
                    .WithMany(o => o.Announcements)
                    .HasForeignKey(a => a.OwnerID)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Announcement { ID = 1, Title = "OOO gasprom", Description = "...", CategoryID = 1, OwnerID = "98b651ae-c9aa-4731-9996-57352d525f7e", RegionID = 1, Status = AnnouncementStatus.Normal }
                );
        }
    }
}
