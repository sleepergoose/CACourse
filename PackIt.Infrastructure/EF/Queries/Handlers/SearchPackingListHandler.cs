using Microsoft.EntityFrameworkCore;
using PackIt.Application.DTO;
using PackIt.Application.Queries;
using PackIt.Infrastructure.EF.Contexts;
using PackIt.Infrastructure.EF.Models;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Infrastructure.EF.Queries.Handlers;

internal sealed class SearchPackingListHandler : IQueryHandler<SearchPackingList, IEnumerable<PackingListDto>>
{
    private readonly DbSet<PackingListReadModel> _packingList;

    public SearchPackingListHandler(ReadDbContext context)
        => _packingList = context.PackingLists;

    public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingList query)
    {
        var dbQuery = _packingList
            .Include(p => p.Items)
            .AsQueryable();

        if (!string.IsNullOrEmpty(query.SearchPhrase))
        {
            dbQuery = dbQuery.Where(p =>
                Microsoft.EntityFrameworkCore.EF.Functions.ILike(p.Name, $"%{query.SearchPhrase}%"));
        }

        return await dbQuery
            .Select(p => p.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}
