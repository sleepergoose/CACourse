using PackIt.Domain.Exceptions.PackingList;
using PackIt.Domain.ValueObjects.PackingList;
using Xunit;

namespace Domain.Tests.ValueObjects;

public class LocalizationTests
{
    [Theory]
    [InlineData("New York, USA")]
    [InlineData("Parice, France")]
    public void Should_Create_Localization_Object(string cityCountry)
    {
        var localization = Localization.Create(cityCountry);

        Assert.NotNull(localization);
        Assert.Contains(localization.City, cityCountry);
        Assert.Contains(localization.Country, cityCountry);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Should_Throw_EmptyLocalizationArgumentException_If_Argument_Is_Null_Or_Empty(string cityCountry)
    {
        Assert.Throws<EmptyLocalizationArgumentException>(() => Localization.Create(cityCountry));
    }

    [Theory]
    [InlineData("New York, USA")]
    [InlineData("Parice, France")]
    public void Should_Convert_To_String(string cityCountry)
    {
        var localization = Localization.Create(cityCountry);

        Assert.Equal(localization.ToString(), cityCountry);
    }
}
