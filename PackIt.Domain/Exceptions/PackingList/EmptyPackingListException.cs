using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions.PackingList;

public sealed class EmptyPackingListException : CACourseException
{
    public EmptyPackingListException() : base("Packing list ID cannot be empty.")
    {

    }
}
