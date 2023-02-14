using Announcements.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Announcements.Infrastructure.DataAccess.EntitiesConfiguration
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.Property(c => c.ParentCategoryID).IsRequired(false);

            builder
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryID);

            builder.HasData(
                    new Category { ID = 1, Name = "resorses" }
            );
        }

    }
}
