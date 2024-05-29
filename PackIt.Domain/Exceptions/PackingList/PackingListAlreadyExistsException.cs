using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions.PackingList;

public sealed class PackingListAlreadyExistsException : CACourseException
{
    public PackingListAlreadyExistsException(string listName, string itemName)
        : base($"Packing list: '{listName}' already defined item '{itemName}'")
    {
    }
}
