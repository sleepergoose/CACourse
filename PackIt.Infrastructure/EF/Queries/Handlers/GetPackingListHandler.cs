using Microsoft.EntityFrameworkCore;
using PackIt.Application.DTO;
using PackIt.Application.Queries;
using PackIt.Infrastructure.EF.Contexts;
using PackIt.Infrastructure.EF.Models;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Infrastructure.EF.Queries.Handlers;

internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
{
    private readonly DbSet<PackingListReadModel> _packingList;

    public GetPackingListHandler(ReadDbContext context)
        => _packingList = context.PackingLists;

    public Task<PackingListDto> HandleAsync(GetPackingList query)
        => _packingList
            .Include(p => p.Items)
            .Where(p => p.Id == query.Id)
            .Select(p => p.AsDto())
            .AsNoTracking() // Because it's only reading operation
            .SingleOrDefaultAsync()!;

}
