using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands;

public record class AddPackingItem(Guid Id, string Name, uint Quantity) : ICommand;
