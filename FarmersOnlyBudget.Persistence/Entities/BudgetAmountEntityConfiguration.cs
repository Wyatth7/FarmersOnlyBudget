using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Entities;

public class BudgetAmountEntityConfiguration : IEntityTypeConfiguration<BudgetAmountEntity>
{
    public void Configure(EntityTypeBuilder<BudgetAmountEntity> builder)
    {
        builder.ToTable("BudgetAmounts");

        builder.HasKey(b => b.BudgetAmountId);

        builder.Property(b => b.Amount)
            .HasDefaultValue(0.0)
            .IsRequired();

        builder.Property(b => b.Remaining)
            .HasDefaultValue(0.0)
            .IsRequired();
    }
}