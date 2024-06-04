using PackIt.Application.DTO;
using PackIt.Application.Queries;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Infrastructure.Queries.Handlers;

public sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
{
    public Task<PackingListDto> HandleAsync(GetPackingList query)
    {
        throw new NotImplementedException();
    }
}
