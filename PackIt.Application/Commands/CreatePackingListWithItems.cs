using PackIt.Domain.Constants;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands;

public record class CreatePackingListWithItems(
    Guid Id,
    string Name,
    ushort Days,
    Gender Gender,
    LocalizationWriteModel Localization) : ICommand;

public record LocalizationWriteModel(string City, string Country);
