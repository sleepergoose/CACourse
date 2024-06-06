using PackIt.Domain.Events;
using PackIt.Domain.Exceptions.PackingList;
using PackIt.Domain.ValueObjects.PackingList;
using PackIt.Shared.Abstractions.Domain;

namespace PackIt.Domain.Entities;

public sealed class PackingList : AggregateRoot<PackingListId>
{
    private readonly PackingListName _name;
    private readonly Localization _localization;

    private readonly LinkedList<PackingListItem> _items = new();

    // public PackingListId Id { get; private set; }

    public PackingList(PackingListId id, PackingListName name, Localization localization)
    {
        Id = id;
        _name = name;
        _localization = localization;
    }

    #pragma warning disable CS8618 
    private PackingList()
    #pragma warning restore CS8618 
    {
        // this parameterless constructor is needed since EF Core requires it in an entities 
        // that are used in interoperation with database
    }

    public void AddItem(PackingListItem item)
    {
        var existingItem = _items.Any(i => i.Name == item.Name);

        if (existingItem)
        {
            throw new PackingListAlreadyExistsException(_name, item.Name);
        }

        _items.AddLast(item);

        AddEvent(new PackingItemAdded(this, item));
    }

    public void AddItems(IEnumerable<PackingListItem> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void PackItem(string itemName)
    {
        var item = GetItem(itemName);
        var packedItem = item with { IsPacked = true };

        var temp = _items.Find(item);

        if (temp is not null)
        {
            temp.Value = packedItem;
        }

        AddEvent(new PackingItemPacked(this, item));
    }

    public void RemoveItem(string itemName)
    {
        var item = GetItem(itemName);
        _items.Remove(item);

        AddEvent(new PackingItemRemoved(this, item));
    }

    private PackingListItem GetItem(string itemName)
    {
        var item = _items.SingleOrDefault(i => i.Name == itemName);

        if (item is null)
        {
            throw new PackingItemNotFoundExceptions(itemName);
        }

        return item;
    }
}
