namespace PackIt.Application.DTO;

public sealed class PackingListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public LocalizationDto Localization { get; set; } = default!;
    public IEnumerable<PackingListItemDto> Items { get; set; } = default!;
}