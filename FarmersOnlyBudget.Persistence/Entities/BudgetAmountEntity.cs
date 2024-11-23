namespace Persistence.Entities;

public class BudgetAmountEntity
{
    public int BudgetAmountId { get; set; }

    public decimal Amount { get; set; }

    public decimal Remaining { get; set; }

    public ICollection<YearBudgetEntity> YearlyBudgets { get; set; } = [];

    public ICollection<MonthBudgetEntity> MonthlyBudgets { get; set; } = [];

    public ICollection<BudgetItemEntity> BudgetItems { get; set; } = [];
}