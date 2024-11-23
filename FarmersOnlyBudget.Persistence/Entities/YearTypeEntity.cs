namespace Persistence.Entities;

public class YearTypeEntity
{
    public int YearTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<YearBudgetEntity> YearlyBudgets { get; set; } = [];
}