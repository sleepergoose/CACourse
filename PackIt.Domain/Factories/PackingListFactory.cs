using PackIt.Domain.Constants;
using PackIt.Domain.Entities;
using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Factories;

internal class PackingListFactory : IPackingListFactory
{
    public PackingList Create(PackingListId id, PackingListName name, Localization localization)
    {
        throw new NotImplementedException();
    }

    public PackingList CreateWithDefaultValues(PackingListId id, PackingListName name, TravelDays days, Gender gender, Temperature temperature, Localization localization)
    {
        throw new NotImplementedException();
    }
}
