using PackIt.Application.Exceptions;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects.PackingList;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers;

public sealed class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
{
    private readonly IPackingListRepository _repository;

    public RemovePackingItemHandler(IPackingListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(RemovePackingItem command)
    {
        var (packingListId, name) = command;

        var packingList = await _repository.GetAsync(packingListId)
            ?? throw new PackingListNotFoundException(packingListId);

        packingList.RemoveItem(name);

        await _repository.UpdateAsync(packingList);
    }
}
