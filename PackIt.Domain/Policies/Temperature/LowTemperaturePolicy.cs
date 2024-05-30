using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Policies.Temperature;

internal sealed class LowTemperaturePolicy : IPackingItemsPolicy
{
    public IEnumerable<PackingListItem> GenerateItems(PolicyData data)
        => new List<PackingListItem>()
        {
            new("Winter hat", 1),
            new("Scarf", 1),
            new("Gloves", 1),
            new("Hoodle", 1),
            new("Warn Jacket", 1),
        };

    public bool IsApplicable(PolicyData data)
        => data.Temperature < 10D;
}
