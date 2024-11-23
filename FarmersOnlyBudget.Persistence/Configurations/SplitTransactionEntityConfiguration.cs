using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class SplitTransactionEntityConfiguration : IEntityTypeConfiguration<SplitTransactionEntity>
{
    public void Configure(EntityTypeBuilder<SplitTransactionEntity> builder)
    {
        builder.ToTable("SplitTransactions");

        builder.HasKey(s => s.SplitTransactionId);
        
        builder.Property(s => s.Amount)
            .HasDefaultValue(0.0)
            .IsRequired();

        builder.HasOne(s => s.Transaction)
            .WithMany(t => t.SplitTransactions)
            .HasForeignKey(s => s.PrincipleTransactionId)
            .IsRequired();

        builder.HasOne(s => s.BudgetItem)
            .WithMany(b => b.SplitTransactions)
            .HasForeignKey(s => s.BudgetItemId)
            .IsRequired();
    }
}