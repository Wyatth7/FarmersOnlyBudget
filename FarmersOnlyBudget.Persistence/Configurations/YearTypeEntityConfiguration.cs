using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class YearTypeEntityConfiguration : IEntityTypeConfiguration<YearTypeEntity>
{
    public void Configure(EntityTypeBuilder<YearTypeEntity> builder)
    {
        builder.ToTable("YearTypes");

        builder.HasKey(y => y.YearTypeId);

        builder.Property(y => y.Name)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(20)
            .IsRequired();
    }
}