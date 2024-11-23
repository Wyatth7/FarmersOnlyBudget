namespace Persistence.Entities;

public class TransactionEntity
{
    public int TransactionId { get; set; }

    public int BudgetItemId { get; set; }

    public decimal Amount { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTimeOffset TransactionDate { get; set; }

    public BudgetItemEntity BudgetItem { get; set; } = null!;

    public ICollection<SplitTransactionEntity> SplitTransactions { get; set; } = [];
}