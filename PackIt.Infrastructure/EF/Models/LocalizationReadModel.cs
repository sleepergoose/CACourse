namespace PackIt.Infrastructure.EF.Models;

internal sealed record class LocalizationReadModel
{
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    public static LocalizationReadModel Create(string value)
    {
        var splitValues = value.Split(',').Select(p => p.Trim());

        return new LocalizationReadModel
        {
            City = splitValues.First(),
            Country = splitValues.Last(),
        };
    }

    public override string ToString()
        => $"{City},{Country}";
}
