using PackIt.Domain.Exceptions.PackingList;
using PackIt.Domain.ValueObjects.PackingList;
using Xunit;

namespace Domain.Tests.ValueObjects;

public class TemperatureTests
{
    [Theory]
    [InlineData(10d)]
    [InlineData(-10d)]
    public void Shoud_Create_An_Object(double value)
    {
        var temperature = new Temperature(value);

        Assert.NotNull(temperature);
    }

    [Theory]
    [InlineData(101d)]
    [InlineData(-101d)]
    public void Should_Throw_InvalidTemperatureExeption_If_Value_Outside_Limits(double value)
    {
        Assert.Throws<InvalidTemperatureExeption>(() => new Temperature(value));
    }

    [Fact]
    public void Should_Convert_Temperature_To_Double()
    {
        var value = 25d;
        var temperature = new Temperature(value);
        double actual = temperature;

        Assert.Equal(value, actual);
    }

    [Fact]
    public void Should_Convert_Double_To_Temperature()
    {
        double value = 25d;
        Temperature temperature = value;

        Assert.NotNull(temperature);
        Assert.Equal(temperature.Value, value);
    }
}
