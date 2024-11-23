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

        builder.HasOne(y => y.User)
            .WithMany(u => u.YearlyBudgets)
            .HasForeignKey(y => y.UserId)
            .IsRequired();

        builder.HasOne(y => y.YearType)
            .WithMany(yt => yt.YearlyBudgets)
            .HasForeignKey(y => y.YearTypeId)
            .IsRequired();

        builder.HasOne(y => y.BudgetAmount)
            .WithMany(b => b.YearlyBudgets)
            .HasForeignKey(y => y.BudgetAmountId)
            .IsRequired();
    }
}