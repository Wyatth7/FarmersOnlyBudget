namespace Persistence.Entities;

public class BudgetItemEntity
{
    public int BudgetItemId { get; set; }

    public int MonthBudgetId { get; set; }

    public int BudgetAmountId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public CategoryEntity Category { get; set; } = null!;

    public MonthBudgetEntity MonthBudget { get; set; } = null!;

    public BudgetAmountEntity BudgetAmount { get; set; } = null!;

    public ICollection<TransactionEntity> Transactions { get; set; } = [];
    
    public ICollection<SplitTransactionEntity> SplitTransactions { get; set; } = [];
}