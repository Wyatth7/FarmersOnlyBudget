using FarmersOnlyBudget.Api.Dto;
using Mapster;
using Persistence;
using Persistence.Entities;

namespace FarmersOnlyBudget.Api.Services;

public class BudgetService(BudgetDbContext dbContext) : IBudgetService
{
    public async Task<int> CreateYearlyBudget(int userId, YearlyBudgetDto dto)
    {
        var yearlyBudget = dto.Adapt<YearBudgetEntity>();
        yearlyBudget.UserId = userId;

        dbContext.YearlyBudgets.Add(yearlyBudget);
        await dbContext.SaveChangesAsync();
        
        return yearlyBudget.YearBudgetId;
    }

    public Task<int> EditYearlyBudget(int yearlyBudgetId, YearlyBudgetDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateMonthlyBudget(int yearlyBudgetId, MonthlyBudgetDto dto)
    {
        var monthlyBudget = dto.Adapt<MonthBudgetEntity>();
        monthlyBudget.YearBudgetId = yearlyBudgetId;

        dbContext.MonthlyBudgets.Add(monthlyBudget);
        await dbContext.SaveChangesAsync();

        return monthlyBudget.MonthBudgetId;
    }

    public Task<int> EditMonthlyBudget(int monthlyBudgetId, decimal amount)
    {
        throw new NotImplementedException();
    }
}