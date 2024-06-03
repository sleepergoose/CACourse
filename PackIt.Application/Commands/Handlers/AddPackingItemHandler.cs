using PackIt.Application.Exceptions;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects.PackingList;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers;

internal sealed class AddPackingItemHandler : ICommandHandler<AddPackingItem>
{
    private readonly IPackingListRepository _repository;

    public AddPackingItemHandler(IPackingListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(AddPackingItem command)
    {
        var (id, name, quantity) = command;

        var packingList = await _repository.GetAsync(id)
            ?? throw new PackingListNotFoundException(id);

        var item = new PackingListItem(name, quantity);

        packingList.AddItem(item);

        await _repository.UpdateAsync(packingList);
    }
}
