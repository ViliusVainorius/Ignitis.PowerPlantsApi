using Ignitis.PowerPlantsApi.Application;
using Ignitis.PowerPlantsApi.Domain.Models;
using Ignitis.PowerPlantsApi.Domain.Models.DTOs;
using Ignitis.PowerPlantsApi.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Ignitis.PowerPlantsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PowerPlantsController(IPowerPlantService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PowerPlant>> Get([FromQuery] string? owner = null, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var powerPlants = await service.GetAsync(owner, page, pageSize);

        return Ok(new { powerPlants });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PowerPlantDto? dto)
    {
        if(dto == null)
            return BadRequest(new PowerPlantBadRequest
            {
                Error = Strings.InvalidRequestBody,
                Details = [Strings.RequestBodyRequirments],
            });

        var validationResult = dto.Validate();

        if (!validationResult.IsValid)
            return BadRequest(new PowerPlantBadRequest
            {
                Error = Strings.ValidationErrorTitle,
                Details = validationResult.Errors
            });

        var created = await service.CreateAsync(dto);

        return Ok(created);
    }
}
