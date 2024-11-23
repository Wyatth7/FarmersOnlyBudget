using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class MonthlyBudgetEntityConfiguration : IEntityTypeConfiguration<MonthBudgetEntity>
{
    public void Configure(EntityTypeBuilder<MonthBudgetEntity> builder)
    {
        builder.ToTable("MonthyBudgets");

        builder.HasKey(m => m.MonthBudgetId);
        
        builder.HasOne(m => m.YearBudget)
            .WithMany(y => y.MonthBudgets)
            .HasForeignKey(m => m.YearBudgetId)
            .IsRequired();

        builder.HasOne(m => m.BudgetAmount)
            .WithMany(b => b.MonthlyBudgets)
            .HasForeignKey(m => m.BudgetAmountId)
            .IsRequired();

        builder.HasOne(m => m.MonthType)
            .WithMany(mt => mt.MonthlyBudgets)
            .HasForeignKey(m => m.MonthTypeId)
            .IsRequired();

    }
}