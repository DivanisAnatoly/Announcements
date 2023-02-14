using Announcements.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcements.Infrastructure.DataAccess.EntitiesConfiguration
{
    class UserFilesConfiguration : IEntityTypeConfiguration<UserFile>
    {
        public void Configure(EntityTypeBuilder<UserFile> builder)
        {
            builder.HasKey(uf => uf.ID);

            builder.Property(uf => uf.UserID).IsRequired();
            builder.Property(uf => uf.Name).IsRequired().HasMaxLength(100);
            builder.Property(uf => uf.Status).IsRequired();

        }

    }
}
