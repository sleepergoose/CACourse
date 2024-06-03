using PackIt.Application.DTO;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Application.Queries;

public sealed record class SearchPackingList(string SearchPhrase) : IQuery<IEnumerable<PackingListDto>>;
