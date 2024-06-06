using PackIt.Application.DTO.External;
using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Application.Services;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(Localization localization);
}
