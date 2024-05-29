using PackIt.Domain.Exceptions.PackingList;

namespace PackIt.Domain.ValueObjects.PackingList;

public class Temperature
{
    public double Value { get; }

    public Temperature(double value)
    {
        if (value < -100 || value > 100)
        {
            throw new InvalidTemperatureExeption(value);
        }

        Value = value;
    }

    public static implicit operator Temperature(double value) => new Temperature(value);
    public static implicit operator double(Temperature temperature) => temperature.Value;
}
