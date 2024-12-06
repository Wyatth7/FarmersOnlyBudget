namespace FarmersOnlyBudget.Api.Services;

public class BudgetService : IBudgetService
{
    public Task<int> CreateYearlyBudget(int userId, decimal amount)
    {
        throw new NotImplementedException();
    }

    public Task<int> EditYearlyBudget(int yearlyBudgetId, decimal amount)
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateMonthlyBudget(int yearlyBudgetId, decimal amount)
    {
        throw new NotImplementedException();
    }

    public Task<int> EditMonthlyBudget(int monthlyBudgetId, decimal amount)
    {
        throw new NotImplementedException();
    }
}