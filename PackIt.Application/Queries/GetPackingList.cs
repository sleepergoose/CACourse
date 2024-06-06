using PackIt.Application.DTO;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Application.Queries;

public sealed record GetPackingList(Guid Id) : IQuery<PackingListDto>;
