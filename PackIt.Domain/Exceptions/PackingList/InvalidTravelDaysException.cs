using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions.PackingList;

public sealed class InvalidTravelDaysException : CACourseException
{
    public InvalidTravelDaysException(ushort days) : base($"Value '{days}' is invalid value of TravelDays")
    {
    }
}
