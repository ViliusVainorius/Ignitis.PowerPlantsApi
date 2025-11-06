namespace Ignitis.PowerPlantsApi.Domain.Models;

public class PowerPlantError
{
    public bool IsValid => Errors.Count == 0;
    public List<string> Errors { get; set; } = [];
}
