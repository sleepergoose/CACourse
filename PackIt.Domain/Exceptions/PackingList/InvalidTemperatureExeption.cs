using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions.PackingList;

public sealed class InvalidTemperatureExeption : CACourseException
{
    public InvalidTemperatureExeption(double temperature)
        : base($"Value '{temperature}' is invalid temperature")
    {
    }
}
