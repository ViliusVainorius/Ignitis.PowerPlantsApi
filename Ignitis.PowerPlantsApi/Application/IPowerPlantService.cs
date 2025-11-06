using Ignitis.PowerPlantsApi.Domain.Models;
using Ignitis.PowerPlantsApi.Domain.Models.DTOs;

namespace Ignitis.PowerPlantsApi.Application;

public interface IPowerPlantService
{
    Task<IEnumerable<PowerPlant>> GetAsync(string? owner, int page = 1, int pageSize = 10);
    Task<PowerPlant> CreateAsync(PowerPlantDto dto);
}
