using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class YearlyBudgetEntityConfiguration : IEntityTypeConfiguration<YearBudgetEntity>
{
    public void Configure(EntityTypeBuilder<YearBudgetEntity> builder)
    {
        builder.ToTable("YearlyBudgets");

        builder.HasKey(y => y.YearBudgetId);

        builder.Property(y => y.Year)
            .HasDefaultValue(0)
            .HasMaxLength(4)
            .IsRequired();
        
        builder.HasOne(y => y.User)
            .WithMany(u => u.YearlyBudgets)
            .HasForeignKey(y => y.UserId)
            .IsRequired();

        builder.HasOne(y => y.BudgetAmount)
            .WithMany(b => b.YearlyBudgets)
            .HasForeignKey(y => y.BudgetAmountId)
            .IsRequired();

        builder.HasIndex(y => y.Year);
    }
}