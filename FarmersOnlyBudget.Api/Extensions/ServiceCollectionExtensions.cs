using System.Reflection;
using FarmersOnlyBudget.Api.Dto;
using FarmersOnlyBudget.Api.Validation;
using FluentValidation;
using Mapster;
using MapsterMapper;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace FarmersOnlyBudget.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddFluentValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator<YearlyBudgetDto>, YearlyBudgetValidator>();
        services.AddFluentValidationAutoValidation();
    }

    public static void AddFarmersOnlyMapster(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddTransient<IMapper, ServiceMapper>();
    }
}