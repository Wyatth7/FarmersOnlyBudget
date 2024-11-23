using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class MonthTypeEntityConfiguration : IEntityTypeConfiguration<MonthTypeEntity>
{
    public void Configure(EntityTypeBuilder<MonthTypeEntity> builder)
    {
        builder.ToTable("MonthTypes");

        builder.HasKey(m => m.MonthTypeId);

        builder.Property(m => m.Name)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(20)
            .IsRequired();
    }
}