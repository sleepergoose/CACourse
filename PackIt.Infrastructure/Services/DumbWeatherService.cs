using PackIt.Application.DTO.External;
using PackIt.Application.Services;
using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Infrastructure.Services;

internal sealed class DumbWeatherService : IWeatherService
{
    public Task<WeatherDto> GetWeatherAsync(Localization localization)
        => Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
}
