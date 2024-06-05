namespace PackIt.Infrastructure.EF.Models;

internal sealed class PackingListReadModel
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string Name { get; set; } = string.Empty;
    public LocalizationReadModel Localization { get; set; } = default!;
    public ICollection<PackingListItemReadModel> Items { get; set; } = default!;
};