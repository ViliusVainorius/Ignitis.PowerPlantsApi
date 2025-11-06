using Ignitis.PowerPlantsApi.Data;
using Ignitis.PowerPlantsApi.Domain.Models;
using Ignitis.PowerPlantsApi.Domain.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ignitis.PowerPlantsApi.Application;

public class PowerPlantService(IgnitisDbContext context) : IPowerPlantService
{
    public async Task<IEnumerable<PowerPlant>> GetAsync(string? owner)
    {
        var query = context.PowerPlants.AsQueryable();

        if (!string.IsNullOrWhiteSpace(owner))
            query = query.Where(p => p.Owner.ToLower().Contains(owner.ToLower()));

        return await query.ToListAsync();
    }

    public async Task<PowerPlant> CreateAsync(PowerPlantDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<ValidationResult> ValidateAsync(PowerPlantDto dto)
    {
        throw new NotImplementedException();
    }
}
