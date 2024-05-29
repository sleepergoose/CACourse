using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions.PackingList;

public sealed class EmptyPackingListItemNameException : CACourseException
{
    public EmptyPackingListItemNameException() : base("Packing list item name cannot be empty")
    {
        
    }
}
