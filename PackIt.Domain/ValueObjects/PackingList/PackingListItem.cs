using PackIt.Domain.Exceptions.PackingList;

namespace PackIt.Domain.ValueObjects.PackingList;

public sealed record PackingListItem
{
    public string Name { get; } = string.Empty;
    public uint Quantity { get; }
    public bool IsPacked { get; init; }

    public PackingListItem(string name, uint quantity, bool isPacked = false)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new EmptyPackingListItemNameException();
        }

        if (quantity <= 0 || quantity > 50)
        {
            throw new InvalidPackingListItemQuantityException();
        }

        Name = name;
        Quantity = quantity;
        IsPacked = isPacked;
    }
}
