namespace Persistence.Entities;

public class SplitTransactionEntity
{
    public int SplitTransactionId { get; set; }

    public int PrincipleTransactionId { get; set; }

    public int BudgetItemId { get; set; }

    public decimal Amount { get; set; }

    public TransactionEntity Transaction { get; set; } = null!;

    public BudgetItemEntity BudgetItem { get; set; } = null!;
}