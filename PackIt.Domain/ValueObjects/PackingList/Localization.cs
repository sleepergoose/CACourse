using PackIt.Domain.Exceptions.PackingList;

namespace PackIt.Domain.ValueObjects.PackingList;

public record Localization(string City, string Country)
{
    public static Localization Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new EmptyLocalizationArgumentException();
        }

        var splitLocalization = value.Split(',').Select(p => p.Trim());

        return new Localization(splitLocalization.First(), splitLocalization.Last());
    }

    public override string ToString() => $"{City}, {Country}";
}
