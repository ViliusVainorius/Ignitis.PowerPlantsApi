namespace Ignitis.PowerPlantsApi.Domain.Models;

public class PowerPlant
{
    public int ID { get; set; }

    public string Owner { get; set; }

    public decimal Power { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }
}
