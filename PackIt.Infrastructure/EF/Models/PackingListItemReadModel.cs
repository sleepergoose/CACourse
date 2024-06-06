namespace PackIt.Infrastructure.EF.Models;

internal sealed class PackingListItemReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public uint Quantity { get; set; }
    public bool IsPacked { get; set; }

    public PackingListReadModel PackingList { get; set; } = default!;
}
