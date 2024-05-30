using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Policies.Gender;

internal class MaleGenderPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data) => data.Gender == Constants.Gender.Male;

    public IEnumerable<PackingListItem> GenerateItems(PolicyData data)
        => new List<PackingListItem>
        {
            new("Laptop", 1),
            new("Beer", 10),
            new("Book", (uint)Math.Ceiling(data.Days / 7m)),
        };
}
