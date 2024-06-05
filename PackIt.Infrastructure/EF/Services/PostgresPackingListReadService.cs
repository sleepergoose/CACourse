using Microsoft.EntityFrameworkCore;
using PackIt.Application.Services;
using PackIt.Infrastructure.EF.Contexts;
using PackIt.Infrastructure.EF.Models;

namespace PackIt.Infrastructure.EF.Services;

internal sealed class PostgresPackingListReadService : IPackingListReadService
{
    private readonly DbSet<PackingListReadModel> _packingLists;

    public PostgresPackingListReadService(ReadDbContext readContext)
        => _packingLists = readContext.PackingLists;

    public Task<bool> ExistsByNameAsync(string name)
        => _packingLists.AnyAsync(p => p.Name == name);
}
