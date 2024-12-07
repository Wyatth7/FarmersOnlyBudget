using FarmersOnlyBudget.Api.Dto;

namespace FarmersOnlyBudget.Api.Services;

public interface IBudgetService
{
    Task<int> CreateYearlyBudget(int userId, YearlyBudgetDto dto);

    Task<int> EditYearlyBudget(int yearlyBudgetId, YearlyBudgetDto dto);

    Task<int> CreateMonthlyBudget(int yearlyBudgetId, decimal amount);

    Task<int> EditMonthlyBudget(int monthlyBudgetId, decimal amount);
}