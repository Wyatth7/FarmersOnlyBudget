using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class BudgetItemEntityConfiguration : IEntityTypeConfiguration<BudgetItemEntity>
{
    public void Configure(EntityTypeBuilder<BudgetItemEntity> builder)
    {
        builder.ToTable("BudgetItems");

        builder.HasKey(b => b.BudgetItemId);
        
        builder.Property(b => b.Name)
            .HasDefaultValue(string.Empty)
            .HasMaxLength(250)
            .IsRequired();

        builder.HasOne(b => b.Category)
            .WithMany(c => c.BudgetItems)
            .HasForeignKey(b => b.CategoryId)
            .IsRequired();

        builder.HasOne(b => b.MonthBudget)
            .WithMany(m => m.BudgetItems)
            .HasForeignKey(b => b.MonthBudgetId)
            .IsRequired();

        builder.HasOne(b => b.BudgetAmount)
            .WithMany(ba => ba.BudgetItems)
            .HasForeignKey(b => b.BudgetAmountId)
            .IsRequired();
    }
}