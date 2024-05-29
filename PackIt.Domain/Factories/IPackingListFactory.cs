using PackIt.Domain.Constants;
using PackIt.Domain.Entities;
using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Factories;

public interface IPackingListFactory
{
    PackingList Create(PackingListId id, PackingListName name, Localization localization);
    PackingList CreateWithDefaultValues(PackingListId id, PackingListName name, TravelDays days, Gender gender,
        Temperature temperature, Localization localization);
}
