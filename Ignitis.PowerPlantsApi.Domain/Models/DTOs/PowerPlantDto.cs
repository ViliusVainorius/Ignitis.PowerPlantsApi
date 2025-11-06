using Ignitis.PowerPlantsApi.Domain.Resources;
using System.Text.RegularExpressions;

namespace Ignitis.PowerPlantsApi.Domain.Models.DTOs;

public class PowerPlantDto
{
    public required string Owner { get; set; }
    public required decimal Power { get; set; }
    public required DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }

    public PowerPlant ToEntity()
    {
        var entity = new PowerPlant
        {
            Owner = this.Owner,
            Power = this.Power,
            ValidFrom = this.ValidFrom,
            ValidTo = this.ValidTo
        };

        return entity;
    }

    public PowerPlantError Validate()
    {
        var result = new PowerPlantError();

        if (string.IsNullOrWhiteSpace(Owner))
            result.Errors.Add(Strings.OwnerInvalid);

        if (Power <= 0)
            result.Errors.Add(Strings.PowerMinValueInvalid);

        if (Power > 200)
            result.Errors.Add(Strings.PowerMaxValueInvalid);

        if (ValidFrom == default)
            result.Errors.Add(Strings.ValidFromNotSet);

        if (!string.IsNullOrWhiteSpace(Owner))
        {
            var ownerRegexPattern = @"^[A-Za-zÀ-ž]+ [A-Za-zÀ-ž]+$";
            if (!Regex.IsMatch(Owner, ownerRegexPattern))
                result.Errors.Add(Strings.OwnerNotTwoWordsInvalid);
        }

        return result;
    }
}
