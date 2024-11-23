namespace Persistence.Entities;

public class MonthTypeEntity
{
    public int MonthTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<MonthBudgetEntity> MonthlyBudgets { get; set; } = [];
}