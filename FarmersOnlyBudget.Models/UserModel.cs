namespace FarmersOnlyBudget.Models;

public class UserModel
{
    public int UserId { get; set; }

    public string NameFirst { get; set; } = string.Empty;

    public string NameLast { get; set; } = string.Empty;

    public string NameFull { get; set; } = string.Empty;

    public string FirebaseId { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
}