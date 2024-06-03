namespace PackIt.Application.DTO;

public sealed record class PackingListDto(
    Guid Id,
    string Name,
    LocalizationDto Localization,
    IEnumerable<PackingListItemDto> Items
);