using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;
using Persistence.Enum;

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

        AddSeedData(builder);
    }

    private static void AddSeedData(EntityTypeBuilder<MonthTypeEntity> builder)
    {
        builder.HasData(
            new MonthTypeEntity { MonthTypeId = (int)MonthType.January, Name = System.Enum.GetName(MonthType.January)! },
            new MonthTypeEntity { MonthTypeId = (int)MonthType.February, Name = System.Enum.GetName(MonthType.February)! },
            new MonthTypeEntity { MonthTypeId = (int)MonthType.March, Name = System.Enum.GetName(MonthType.March)! },
            new MonthTypeEntity { MonthTypeId = (int)MonthType.April, Name = System.Enum.GetName(MonthType.April)! },
            new MonthTypeEntity { MonthTypeId = (int)MonthType.May, Name = System.Enum.GetName(MonthType.May)! },
            new MonthTypeEntity { MonthTypeId = (int)MonthType.June, Name = System.Enum.GetName(MonthType.June)! },
            new MonthTypeEntity { MonthTypeId = (int)MonthType.July, Name = System.Enum.GetName(MonthType.July)! },
            new MonthTypeEntity { MonthTypeId = (int)MonthType.August, Name = System.Enum.GetName(MonthType.August)! },
            new MonthTypeEntity { MonthTypeId = (int)MonthType.September, Name = System.Enum.GetName(MonthType.September)! },
            new MonthTypeEntity { MonthTypeId = (int)MonthType.October, Name = System.Enum.GetName(MonthType.October)! },
            new MonthTypeEntity { MonthTypeId = (int)MonthType.November, Name = System.Enum.GetName(MonthType.November)! },
            new MonthTypeEntity { MonthTypeId = (int)MonthType.December, Name = System.Enum.GetName(MonthType.December)! }
        );
    }
}