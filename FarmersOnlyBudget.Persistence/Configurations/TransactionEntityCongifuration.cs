using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;

namespace Persistence.Configurations;

public class TransactionEntityCongifuration : IEntityTypeConfiguration<TransactionEntity>
{
    public void Configure(EntityTypeBuilder<TransactionEntity> builder)
    {
        builder.ToTable("Transactions");

        builder.HasKey(t => t.TransactionId);

        builder.Property(t => t.Amount)
            .HasDefaultValue(0.0)
            .IsRequired();

        builder.Property(t => t.Name)
            .HasDefaultValue(string.Empty)
            .IsRequired();

        builder.Property(t => t.TransactionDate)
            .HasDefaultValue(DateTimeOffset.MinValue)
            .IsRequired();

        builder.HasOne(t => t.BudgetItem)
            .WithMany(b => b.Transactions)
            .HasForeignKey(t => t.BudgetItemId)
            .IsRequired();
    }
}