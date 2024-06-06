using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands;

public record class DeletePackingList(Guid Id) : ICommand;
