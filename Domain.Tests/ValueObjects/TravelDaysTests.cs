using PackIt.Domain.Exceptions.PackingList;
using PackIt.Domain.ValueObjects.PackingList;
using Xunit;

namespace Domain.Tests.ValueObjects;
public class TravelDaysTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(100)]
    public void Shoud_Create_An_Object(ushort value)
    {
        var days = new TravelDays(value);

        Assert.NotNull(days);
    }

    [Theory]
    [InlineData(101)]
    public void Should_Throw_InvalidTravelDaysException_If_Value_Outside_Boundaries(ushort value)
    {
        Assert.Throws<InvalidTravelDaysException>(() => new TravelDays(value));
    }

    [Fact]
    public void Should_Convert_TravelDays_To_Ushort()
    {
        ushort expected = 25;
        var days = new TravelDays(expected);
        ushort actual = days;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_Convert_Ushort_To_TravelDays()
    {
        ushort expected = 25;
        TravelDays days = expected;

        Assert.NotNull(days);
        Assert.Equal(days.Value, expected);
    }
}
