using PackIt.Domain.ValueObjects.PackingList;
using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Application.Exceptions;

public class MissingLocalizationWeatherException : CACourseException
{
    public Localization Localization { get; }

    public MissingLocalizationWeatherException(Localization localization)
        : base($"Could not fetch weather data for localization {localization.Country}/{localization.City}")
    {
        Localization = localization;
    }
}
