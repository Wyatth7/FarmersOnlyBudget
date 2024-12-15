using Mapster;
using Persistence.Entities;

namespace FarmersOnlyBudget.Api.Dto.Mapping;

public class MonthlyBudgetRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<MonthlyBudgetDto, MonthBudgetEntity>()
            .Map(d => d.MonthTypeId, s => (int)s.Month)
            .Map(d => d.BudgetAmount, s => new BudgetAmountEntity { Amount = s.Amount });
    }
}