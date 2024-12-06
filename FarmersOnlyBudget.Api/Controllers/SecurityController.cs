using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersOnlyBudget.Api.Controllers;

public class SecurityController : BaseApiController
{

    [HttpGet("token/{uid:required}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetToken([FromRoute] string uid)
    {
        var customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(uid);
        
        return new OkObjectResult(new { Token = customToken });
    }
    
}