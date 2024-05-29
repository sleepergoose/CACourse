using PackIt.Domain.Exceptions.PackingList;

namespace PackIt.Domain.ValueObjects.PackingList;

public sealed record PackingListId
{
    public Guid Value { get; }

    public PackingListId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyPackingListException();
        }

        Value = value;
    }

    public static implicit operator Guid(PackingListId id)
        => id.Value;

    public static implicit operator PackingListId(Guid id) 
        => new PackingListId(id);
}
