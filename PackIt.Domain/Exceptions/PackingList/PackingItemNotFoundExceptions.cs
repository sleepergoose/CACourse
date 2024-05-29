using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions.PackingList;

internal class PackingItemNotFoundExceptions : CACourseException
{
    public string ItemName { get; }

    public PackingItemNotFoundExceptions(string itemName) : base($"Packing item '{itemName}' was not found")
        => ItemName = itemName;
}
