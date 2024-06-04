using PackIt.Domain.Exceptions.PackingList;

namespace PackIt.Domain.ValueObjects.PackingList;

public sealed record PackingListName
{
    public string Value { get; } = string.Empty;

    public PackingListName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new EmptyPackingListNameException();
        }

        Value = value;
    }

    public static implicit operator string(PackingListName name) => name.Value;

    public static implicit operator PackingListName(string name) => new PackingListName(name);
}
