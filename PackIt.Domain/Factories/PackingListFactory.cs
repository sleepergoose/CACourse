using PackIt.Domain.Constants;
using PackIt.Domain.Entities;
using PackIt.Domain.Policies;
using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Factories;

internal class PackingListFactory : IPackingListFactory
{
    private readonly IEnumerable<IPackingItemsPolicy> _policies;

    public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
        => _policies = policies;

    public PackingList Create(PackingListId id, PackingListName name, Localization localization)
        => new PackingList(id, name, localization);

    public PackingList CreateWithDefaultValues(PackingListId id, PackingListName name, TravelDays days, Gender gender,
        Temperature temperature, Localization localization)
    {
        var policyData = new PolicyData(days, gender, temperature, localization);
        var applicablePolicies = _policies.Where(p => p.IsApplicable(policyData));

        var packingListItems = applicablePolicies.SelectMany(p => p.GenerateItems(policyData));
        var packingList = this.Create(id, name, localization);

        packingList.AddItems(packingListItems);

        return packingList;
    }
}
