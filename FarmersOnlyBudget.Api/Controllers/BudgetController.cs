using FarmersOnlyBudget.Api.Dto;
using FarmersOnlyBudget.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmersOnlyBudget.Api.Controllers;

public class BudgetController(IBudgetService budgetService, IAuthenticatedUserService authenticatedUserService) : BaseApiController
{
    [HttpPost("year")]
    public async Task<IActionResult> CreateYearlyBudget([FromBody] YearlyBudgetDto yearlyBudgetDto)
    {
        var result = await budgetService.CreateYearlyBudget(authenticatedUserService.User.UserId, yearlyBudgetDto);
        return new OkObjectResult(result);
    }

    [HttpPut("year/{yearlyBudgetId:int:required}")]
    public async Task<IActionResult> EditYearlyBudget(int yearlyBudgetId, [FromBody] YearlyBudgetDto yearlyBudgetDto)
    {
        var result = await budgetService.EditYearlyBudget(yearlyBudgetId, yearlyBudgetDto);
        return new OkObjectResult(result);
    }
    
    [HttpPost("month/{yearlyBudgetId:int:required}")]
    public async Task<IActionResult> CreateMonthlyBudget([FromRoute] int yearlyBudgetId, [FromBody] MonthlyBudgetDto monthlyBudgetDto)
    {
        var result = await budgetService.CreateMonthlyBudget(yearlyBudgetId, monthlyBudgetDto);
        return new OkObjectResult(result);
    }

    [HttpPut("month/{monthlyBudgetId:int:required}")]
    public async Task<IActionResult> EditMonthlyBudget(int monthlyBudgetId, [FromBody] MonthlyBudgetDto monthlyBudgetDto)
    {
        return new OkResult();
    }
}