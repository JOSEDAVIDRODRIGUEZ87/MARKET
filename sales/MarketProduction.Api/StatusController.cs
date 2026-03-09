using Microsoft.AspNetCore.Mvc;

namespace MarketProduction.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "¡La API está lista para los productos!" });
    }
}