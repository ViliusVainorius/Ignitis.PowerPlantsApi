using Ignitis.PowerPlantsApi.Domain.Models;
using Ignitis.PowerPlantsApi.Domain.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Ignitis.PowerPlantsApi.Application;

public interface IPowerPlantService
{
    Task<IEnumerable<PowerPlant>> GetAsync(string? owner);
    Task<ValidationResult> ValidateAsync(PowerPlantDto dto);
    Task<PowerPlant> CreateAsync(PowerPlantDto dto);
}
