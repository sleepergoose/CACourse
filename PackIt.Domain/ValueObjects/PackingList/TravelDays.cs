using PackIt.Domain.Exceptions.PackingList;

namespace PackIt.Domain.ValueObjects.PackingList;

public record class TravelDays
{
    public ushort Value { get; }

    public TravelDays(ushort value)
    {
        if (value < 0 || value > 100)
        {
            throw new InvalidTravelDaysException(value);
        }

        Value = value;
    }

    public static implicit operator TravelDays(ushort value) => new TravelDays(value);

    public static implicit operator ushort(TravelDays value) => value.Value;
}
