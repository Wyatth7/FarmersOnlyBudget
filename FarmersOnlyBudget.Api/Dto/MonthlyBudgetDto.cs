using Persistence.Enum;

namespace FarmersOnlyBudget.Api.Dto;

public class MonthlyBudgetDto
{
    public MonthType Month { get; set; }

    public decimal Amount { get; set; }
}