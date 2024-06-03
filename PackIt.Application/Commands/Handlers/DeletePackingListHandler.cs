using PackIt.Application.Exceptions;
using PackIt.Domain.Repositories;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers;

internal sealed class DeletePackingListHandler : ICommandHandler<DeletePackingList>
{
    private readonly IPackingListRepository _packingListRepository;

    public DeletePackingListHandler(IPackingListRepository packingListRepository)
        => _packingListRepository = packingListRepository;

    public async Task HandleAsync(DeletePackingList command)
    {
        var packingList = await _packingListRepository.GetAsync(command.Id)
            ?? throw new PackingListNotFoundException(command.Id);

        await _packingListRepository.DeleteAsync(packingList);
    }
}
