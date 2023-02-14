using Announcements.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcements.Infrastructure.DataAccess.EntitiesConfiguration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.ID);

            builder.Property(u => u.UserName).IsRequired(false).HasMaxLength(256);
            builder.Property(u => u.Email).IsRequired(false).HasMaxLength(256);
            builder.Property(u => u.PhoneNumber).IsRequired(false).HasMaxLength(12);
            builder.Property(u => u.Status).IsRequired();

            builder.Ignore(u => u.UserName);
            builder.Ignore(u => u.Email);
            builder.Ignore(u => u.PhoneNumber);
            builder.Ignore(u => u.Role);

            builder.HasData(
                new User { ID = "98b651ae-c9aa-4731-9996-57352d525f7e", Status = UserStatus.Normal });

        }

    }
}
