namespace PackIt.Application.DTO;

public sealed record class PackingListItemDto(string Name, uint Quantity, bool IsPacked);
