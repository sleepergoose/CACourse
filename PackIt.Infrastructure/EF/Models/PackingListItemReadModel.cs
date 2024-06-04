namespace PackIt.Infrastructure.EF.Models;

internal sealed record class PackingListItemReadModel(
    Guid Id,
    string Name,
    uint Quantity,
    bool IsPacked,
    PackingListReadModel PackingList
);


//public sealed record class PackingListItemReadModel
//{
//    public Guid Id { get; set; }
//    public string Name { get; set; } = string.Empty;
//    public uint Quantity { get; set; }
//    public bool IsPacked { get; set; }

//    public PackingListItemReadModel PackingList { get; set; }
//}