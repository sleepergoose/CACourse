using PackIt.Application.Exceptions;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects.PackingList;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers;

public sealed class PackItemHandler : ICommandHandler<PackItem>
{
    private readonly IPackingListRepository _repository;

    public PackItemHandler(IPackingListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(PackItem command)
    {
        var (packingListId, name) = command;

        var packingList = await _repository.GetAsync(packingListId)
            ?? throw new PackingListNotFoundException(packingListId);

        packingList.PackItem(name);

        await _repository.UpdateAsync(packingList);
    }
}
