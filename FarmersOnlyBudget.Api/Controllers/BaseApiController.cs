using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmersOnlyBudget.Api.Controllers;

[Route("p/[controller]")]
[Authorize]
public class BaseApiController : Controller
{
    
}