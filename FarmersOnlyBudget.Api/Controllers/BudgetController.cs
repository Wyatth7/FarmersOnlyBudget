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
    
    [HttpPost("month")]
    public async Task<IActionResult> CreateMonthlyBudget([FromBody] MonthlyBudgetDto monthlyBudgetDto)
    {
        return new OkResult();
    }

    [HttpPut("month/{monthlyBudgetId:int:required}")]
    public async Task<IActionResult> EditMonthlyBudget(int monthlyBudgetId, [FromBody] MonthlyBudgetDto monthlyBudgetDto)
    {
        return new OkResult();
    }
}