namespace Ignitis.PowerPlantsApi.Domain.Models.DTOs;

public class PowerPlantDto
{
    public required string Owner { get; set; }
    public required decimal Power { get; set; }
    public required DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}
