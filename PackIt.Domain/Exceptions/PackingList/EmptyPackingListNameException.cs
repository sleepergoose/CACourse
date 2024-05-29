using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions.PackingList;

public sealed class EmptyPackingListNameException : CACourseException
{
    public EmptyPackingListNameException() : base("Packing list name cannot be empty.")
    {
    }
}
