using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands;

public record class RemovePackingItem(Guid PackingListId, string Name) : ICommand;
