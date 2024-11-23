namespace Persistence.Entities;

public class UserEntity
{
    public int UserId { get; set; }

    public string NameFirst { get; set; } = string.Empty;

    public string NameLast { get; set; } = string.Empty;

    public string NameFull { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public ICollection<YearBudgetEntity> YearlyBudgets { get; set; } = [];
}