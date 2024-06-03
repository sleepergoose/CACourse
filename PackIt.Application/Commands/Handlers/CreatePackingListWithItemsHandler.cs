using PackIt.Application.Exceptions;
using PackIt.Application.Services;
using PackIt.Domain.Factories;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects.PackingList;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers;

public sealed class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
{
    private readonly IPackingListRepository _packingListRepository;
    private readonly IPackingListReadService _packingListReadService;
    private readonly IPackingListFactory _packingListFactory;
    private readonly IWeatherService _weatherService;

    public CreatePackingListWithItemsHandler(
    IPackingListRepository packingListRepository,
    IPackingListReadService packingListReadService,
    IPackingListFactory packingListFactory
,
    IWeatherService weatherService)
    {
        _packingListRepository = packingListRepository;
        _packingListFactory = packingListFactory;
        _packingListReadService = packingListReadService;
        _weatherService = weatherService;
    }

    public async Task HandleAsync(CreatePackingListWithItems command)
    {
        var (id, name, days, gender, localizationWritemodel) = command;

        if (await _packingListReadService.ExistsByNameAsync(name))
        {
            throw new PackingListAlreadyExistsException(name);
        }

        var localization = new Localization(localizationWritemodel.City, localizationWritemodel.Country);

        var weather = await _weatherService.GetWeatherAsync(localization)
            ?? throw new MissingLocalizationWeatherException(localization);

        var packingList = _packingListFactory.CreateWithDefaultValues(id, name, days, gender, weather.Temperature, localization);

        await _packingListRepository.AddAsync(packingList);
    }
}
