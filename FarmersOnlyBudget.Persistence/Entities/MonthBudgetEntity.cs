namespace Persistence.Entities;

public class MonthBudgetEntity
{
    public int MonthBudgetId { get; set; }

    public int YearBudgetId { get; set; }

    public int BudgetAmountId { get; set; }

    public int MonthTypeId { get; set; }

    public YearBudgetEntity YearBudget { get; set; } = null!;

    public BudgetAmountEntity BudgetAmount { get; set; } = null!;

    public MonthTypeEntity MonthType { get; set; } = null!;

    public ICollection<BudgetItemEntity> BudgetItems { get; set; } = [];
}