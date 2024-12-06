namespace FarmersOnlyBudget.Api.Dto;

public class CreateEditEntryDto
{
    public string Name { get; set; } = string.Empty;
    
    public decimal Amount { get; set; }
}