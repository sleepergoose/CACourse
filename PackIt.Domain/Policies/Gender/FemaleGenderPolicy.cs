using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Policies.Gender;

internal sealed class FemaleGenderPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data) 
        => data.Gender == Constants.Gender.Female;

    public IEnumerable<PackingListItem> GenerateItems(PolicyData data)
        => new List<PackingListItem>
        {
            new("Lipstick", 1),
            new("Powder", 1),
            new("Eyeliner", 1),
        };
}
