using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class CategoryTypeEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Catagories");

        builder.HasKey(c => c.CategoryId);

        builder.Property(c => c.Name)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(250)
            .IsRequired();
    }
}