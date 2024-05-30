using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Policies.Temperature;

internal sealed class HighTemperaturePolicy : IPackingItemsPolicy
{
    public IEnumerable<PackingListItem> GenerateItems(PolicyData data)
        => new List<PackingListItem>
        {
            new("Hat", 1),
            new("Sunglasses", 1),
            new("Cream with UV filter", 1),
        };

    public bool IsApplicable(PolicyData data)
        => data.Temperature > 25D;
}
