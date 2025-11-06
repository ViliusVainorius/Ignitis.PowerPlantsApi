using Ignitis.PowerPlantsApi.Domain.Models.DTOs;

namespace Ignitis.PowerPlantsApi.Unit.Tests;

[TestClass]
public class PowerPlantServiceTests
{
    [TestMethod]
    public void Validate_EmptyOwnerString_ValidationError()
    {
        var dto = new PowerPlantDto
        {
            Owner = string.Empty,
            Power = 1m,
            ValidFrom = new DateTime(2025, 11, 1)
        };

        var result = dto.Validate();

        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Contains("Owner is required."));
    }

    [TestMethod]
    public void Validate_PowerZeroOrLess_ValidationError()
    {
        var dto = new PowerPlantDto
        {
            Owner = "Jonas Jonaitis",
            Power = -1m,
            ValidFrom = new DateTime(2025, 11, 1)
        };

        var result = dto.Validate();

        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Contains("Power must be greater than 0."));
    }

    [TestMethod]
    public void Validate_PowerMoreThan200_ValidationError()
    {
        var dto = new PowerPlantDto
        {
            Owner = "Jonas Jonaitis",
            Power = 300m,
            ValidFrom = new DateTime(2025, 11, 1)
        };

        var result = dto.Validate();

        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Contains("Power must not exceed 200."));
    }

    [TestMethod]
    public void Validate_ValidFromNotSet_ValidationError()
    {
        var dto = new PowerPlantDto
        {
            Owner = "Jonas Jonaitis",
            Power = 1m,
            ValidFrom = default
        };

        var result = dto.Validate();

        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Contains("ValidFrom is required."));
    }

    [TestMethod]
    public void Validate_InvalidOwnerFormat_ValidationError()
    {
        var dto = new PowerPlantDto
        {
            Owner = "Jonas",
            Power = 1m,
            ValidFrom = new DateTime(2025, 11, 1)
        };

        var result = dto.Validate();

        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Contains("Owner must consist of two words with letters only, separated by a space."));
    }
}
