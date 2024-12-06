namespace FarmersOnlyBudget.Api.Services;

public interface IBudgetService
{
    Task<int> CreateYearlyBudget(int userId, decimal amount);

    Task<int> EditYearlyBudget(int yearlyBudgetId, decimal amount);

    Task<int> CreateMonthlyBudget(int yearlyBudgetId, decimal amount);

    Task<int> EditMonthlyBudget(int monthlyBudgetId, decimal amount);
}