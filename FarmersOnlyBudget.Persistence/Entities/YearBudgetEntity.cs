namespace Persistence.Entities;

public class YearBudgetEntity
{
    public int YearBudgetId { get; set; }

    public int UserId { get; set; }

    public int YearTypeId { get; set; }

    public int BudgetAmountId { get; set; }

    public UserEntity User { get; set; } = null!;

    public BudgetAmountEntity BudgetAmount { get; set; } = null!;

    public YearTypeEntity YearType { get; set; } = null!;

    public ICollection<MonthBudgetEntity> MonthBudgets { get; set; } = [];
}