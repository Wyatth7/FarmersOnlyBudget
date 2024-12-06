using FarmersOnlyBudget.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FarmersOnlyBudget.Api.Controllers;

public class BudgetItemController : BaseApiController
{

    [HttpPost]
    [Consumes("application/json")]
    public async Task<IActionResult> Create([FromBody] CreateEditEntryDto createEditEntryDto)
    {
        return new OkResult();
    }

    
    [HttpPut("{budgetItemId:int:required}")]
    [Consumes("application/json")]
    public async Task<IActionResult> Edit(int budgetItemId, [FromBody] CreateEditEntryDto createEditEntryDto)
    {
        return new OkResult();
    }

    [HttpDelete("{budgetItemId:int:required}")]
    public async Task<IActionResult> Delete(int budgetItemId)
    {
        return new OkResult();
    }
    
}