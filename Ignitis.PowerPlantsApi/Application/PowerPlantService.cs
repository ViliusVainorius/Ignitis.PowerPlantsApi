using Ignitis.PowerPlantsApi.Data;
using Ignitis.PowerPlantsApi.Domain.Models;
using Ignitis.PowerPlantsApi.Domain.Models.DTOs;
using Ignitis.PowerPlantsApi.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Ignitis.PowerPlantsApi.Application;

public class PowerPlantService(IgnitisDbContext context) : IPowerPlantService
{
    public IQueryable<PowerPlant> query = context.PowerPlants.AsQueryable();

    public async Task<IEnumerable<PowerPlant>> GetAsync(string? owner, int page = 1, int pageSize = 10)
    {
        var powerPlants = await query.ToListAsync();

        if (!string.IsNullOrWhiteSpace(owner))
        {
            var filter = owner.NormalizeWithoutAccents().ToLower();

            powerPlants = powerPlants
                .Where(p => p.Owner.NormalizeWithoutAccents().ToLower().Contains(filter))
                .ToList();
        }

        return powerPlants
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public async Task<PowerPlant> CreateAsync(PowerPlantDto dto)
    {
        var newPowerPlant = dto.ToEntity();

        context.PowerPlants.Add(newPowerPlant);

        await context.SaveChangesAsync();

        return newPowerPlant;
    }
}
