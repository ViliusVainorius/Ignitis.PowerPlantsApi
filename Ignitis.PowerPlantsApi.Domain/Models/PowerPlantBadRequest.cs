namespace Ignitis.PowerPlantsApi.Domain.Models;

public class PowerPlantBadRequest
{
    public required string Error { get; set; }
    public List<string> Details { get; set; } = [];
}
