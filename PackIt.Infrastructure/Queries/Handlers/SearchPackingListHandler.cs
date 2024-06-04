using PackIt.Application.DTO;
using PackIt.Application.Queries;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Infrastructure.Queries.Handlers;

public sealed class SearchPackingListHandler : IQueryHandler<SearchPackingList, IEnumerable<PackingListDto>>
{
    public Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingList query)
    {
        throw new NotImplementedException();
    }
}
