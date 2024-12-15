using FarmersOnlyBudget.Api.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Enum;

namespace FarmersOnlyBudget.Api.Validation;

public class MonthlyBudgetValidator : HttpValidator<MonthlyBudgetDto>
{
    private readonly BudgetDbContext _dbContext;
    private readonly int _yearlyBudgetId;
    
    public MonthlyBudgetValidator(BudgetDbContext dbContext, IActionContextAccessor contextAccessor)
        : base(contextAccessor)
    {
        _dbContext = dbContext;
        _yearlyBudgetId = GetValueFromRoute<int>("yearlyBudgetId");
        
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.Month)
            .MustAsync(MonthExists)
            .WithMessage("You already have a budget for the selected month.");
    }

    private async Task<bool> MonthExists(MonthlyBudgetDto dto, MonthType monthType, CancellationToken token)
        => !await _dbContext.MonthlyBudgets
            .AnyAsync(a => a.YearBudgetId == _yearlyBudgetId && (MonthType)a.MonthTypeId == monthType, token);
}