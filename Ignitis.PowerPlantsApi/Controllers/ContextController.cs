using Ignitis.PowerPlantsApi.Data;
using Ignitis.PowerPlantsApi.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ignitis.PowerPlantsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContextController(IgnitisDbContext context) : ControllerBase
{
    [HttpPost("Migrate")]
    public IActionResult Migrate()
    {
        try
        {
            context.Database.Migrate();
            return Ok(Strings.DatabaseMigrated);
        }
        catch (Exception ex)
        {
            return StatusCode(500, string.Format(Strings.DatabaseMigrationFailed, ex.Message));
        }
    }
}
