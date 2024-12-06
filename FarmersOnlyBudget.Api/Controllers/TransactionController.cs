using FarmersOnlyBudget.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FarmersOnlyBudget.Api.Controllers;

public class TransactionController : BaseApiController
{

    [HttpPost]
    [Consumes("application/json")]
    public async Task<IActionResult> Create([FromBody] CreateEditEntryDto transaction)
    {
        return new OkResult();
    }

    [HttpPut("{transactionId:int:required}")]
    [Consumes("application/json")]
    public async Task<IActionResult> Edit(int transactionId, [FromBody] CreateEditEntryDto transaction)
    {
        return new OkResult();
    }

    [HttpDelete("{transactionId:int:required}")]
    public async Task<IActionResult> Delete(int transactionId)
    {
        return new OkResult();
    }
    
}