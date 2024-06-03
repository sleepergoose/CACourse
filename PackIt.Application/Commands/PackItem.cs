using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands;

public record class PackItem(Guid PackingListId, string Name) : ICommand;
