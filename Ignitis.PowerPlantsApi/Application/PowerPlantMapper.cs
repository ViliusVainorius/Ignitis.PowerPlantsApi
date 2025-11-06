using Ignitis.PowerPlantsApi.Domain.Models;
using Ignitis.PowerPlantsApi.Domain.Models.DTOs;

namespace Ignitis.PowerPlantsApi.Application;

public static class PowerPlantMapper
{
    public static void Map(this PowerPlant powerPlant, PowerPlantDto dto)
    {
        powerPlant.Owner = dto.Owner;
        powerPlant.Power = dto.Power;
        powerPlant.ValidFrom = dto.ValidFrom;
        powerPlant.ValidTo = dto.ValidTo;
    }
}
