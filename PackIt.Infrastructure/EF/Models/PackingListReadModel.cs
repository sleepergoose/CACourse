namespace PackIt.Infrastructure.EF.Models;

internal sealed record class PackingListReadModel(
    Guid Id,
    int Version,
    string Name,
    LocalizationReadModel Localization,
    ICollection<PackingListItemReadModel> Items
);