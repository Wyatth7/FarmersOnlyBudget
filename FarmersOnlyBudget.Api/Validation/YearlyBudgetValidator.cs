using FarmersOnlyBudget.Api.Dto;
using FluentValidation;

namespace FarmersOnlyBudget.Api.Validation;

public class YearlyBudgetValidator : ValidatorBase<YearlyBudgetDto>
{
    public YearlyBudgetValidator()
    {
        RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Year).GreaterThanOrEqualTo(2020);
    }
}