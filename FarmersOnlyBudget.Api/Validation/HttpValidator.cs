using FluentValidation;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FarmersOnlyBudget.Api.Validation;

public class HttpValidator<TType>(IActionContextAccessor contextAccessor) : AbstractValidator<TType>
{
    
    protected TValueType? GetValueFromRoute<TValueType>(string key)
    {
        if (contextAccessor.ActionContext is null)
            return default;
        
        var value = contextAccessor.ActionContext.RouteData.Values
            .GetValueOrDefault(key) ?? default;

        return (TValueType?)Convert.ChangeType(value, typeof(TValueType?));
    }

}