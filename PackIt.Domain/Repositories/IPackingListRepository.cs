using PackIt.Domain.Entities;
using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Repositories;

/// <summary>
/// Repository interfaces in the Domain layer is just a contract that declares what we can do with the PackingList domain.
/// </summary>
public interface IPackingListRepository
{
    Task<PackingList?> GetAsync(PackingListId id);
    Task AddAsync(PackingList packingList);
    Task UpdateAsync(PackingList packingList);
    Task DeleteAsync(PackingList packingList);
}
