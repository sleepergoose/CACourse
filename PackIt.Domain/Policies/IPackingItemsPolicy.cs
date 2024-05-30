using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Policies;

public interface IPackingItemsPolicy
{
    bool IsApplicable(PolicyData data);
    IEnumerable<PackingListItem> GenerateItems(PolicyData data);
}
