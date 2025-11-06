using Ignitis.PowerPlantsApi.Application;
using Ignitis.PowerPlantsApi.Domain.Models;
using Ignitis.PowerPlantsApi.Domain.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Ignitis.PowerPlantsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PowerPlantsController(IPowerPlantService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PowerPlant>> Get([FromQuery] string? owner = null)
    {
        var powerPlants = await service.GetAsync(owner);

        return Ok(powerPlants);
    }

    //[HttpPost]
    //public async Task<IActionResult> Create([FromBody] PowerPlantDto dto)
    //{
    //    var validationResult = await service.ValidateAsync(dto);
    //    if (!validationResult.IsValid)
    //    {
    //        return BadRequest(new
    //        {
    //            error = "Validation Failed",
    //            details = validationResult.Errors
    //        });
    //    }

    //    var created = await service.CreateAsync(dto);
    //    return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    //}
}
