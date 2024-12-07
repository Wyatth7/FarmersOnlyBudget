namespace FarmersOnlyBudget.Api.Dto;

public class YearlyBudgetDto
{
    public DateTimeOffset Date { get; set; }
    
    public decimal Amount { get; set; }

    public int Year => Date.Year;
}