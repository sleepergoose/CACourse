using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions.PackingList;

public sealed class InvalidPackingListItemQuantityException : CACourseException
{
    public InvalidPackingListItemQuantityException()
        : base("Packing list item quantity cannot be less than 0 and greater than 50")
    {
    }
}
