using Microsoft.EntityFrameworkCore;
using PackIt.Domain.Entities;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects.PackingList;
using PackIt.Infrastructure.EF.Contexts;

namespace PackIt.Infrastructure.EF.Repositories;

internal sealed class PostgresPackingListRepository : IPackingListRepository
{
    private readonly DbSet<PackingList> _packinfLists;
    private readonly WriteDbContext _writeDbContext;

    public PostgresPackingListRepository(DbSet<PackingList> packinfLists, WriteDbContext writeDbContext)
    {
        _packinfLists = packinfLists;
        _writeDbContext = writeDbContext;
    }

    public async Task AddAsync(PackingList packingList)
    {
        _packinfLists.Add(packingList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(PackingList packingList)
    {
        _packinfLists.Remove(packingList);
        await _writeDbContext.SaveChangesAsync();
    }

    public Task<PackingList?> GetAsync(PackingListId id)
        => _packinfLists.Include("_items").SingleOrDefaultAsync(p => p.Id == id);

    public async Task UpdateAsync(PackingList packingList)
    {
        _packinfLists.Update(packingList);
        await _writeDbContext.SaveChangesAsync();
    }
}
