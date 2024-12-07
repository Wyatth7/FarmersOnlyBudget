using Mapster;
using Persistence.Entities;

namespace FarmersOnlyBudget.Api.Dto.Mapping;

public class YearBudgetRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<YearlyBudgetDto, YearBudgetEntity>()
            .Map(d => d.BudgetAmount, s => new BudgetAmountEntity { Amount = s.Amount, Remaining = s.Amount });
    }
}