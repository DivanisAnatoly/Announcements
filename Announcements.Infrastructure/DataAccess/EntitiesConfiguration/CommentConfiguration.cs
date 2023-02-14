using Announcements.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcements.Infrastructure.DataAccess.EntitiesConfiguration
{
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Text).IsRequired().HasMaxLength(2000);
            builder.Property(c => c.AuthorID).IsRequired();
            builder.Property(c => c.AnnouncementID).IsRequired();
            builder.Property(c => c.PublishDate).IsRequired();

            builder.HasOne(c => c.Author)
                    .WithMany(a => a.Comments)
                    .HasForeignKey(c => c.AuthorID)
                    .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Announcement)
                    .WithMany(a => a.Comments)
                    .HasForeignKey(c => c.AnnouncementID)
                    .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
