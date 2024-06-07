using NSubstitute;
using PackIt.Application.Commands;
using PackIt.Application.Commands.Handlers;
using PackIt.Application.Services;
using PackIt.Domain.Factories;
using PackIt.Domain.Repositories;
using PackIt.Shared.Abstractions.Commands;
using PackIt.Domain.Constants;
using Shouldly;
using PackIt.Application.Exceptions;
using PackIt.Domain.ValueObjects.PackingList;
using PackIt.Application.DTO.External;
using PackIt.Domain.Entities;

namespace Application.Tests;

public class CreatePackingListWithItemsHandlerTests
{
    Task Act(CreatePackingListWithItems command)
        => _commandHandler.HandleAsync(command);

    [Fact]
    public async Task HandleAsync_Throws_PackingListAlreadyExistsException_When_List_With_Same_Name_Already_Exists()
    {
        var command = new CreatePackingListWithItems(Guid.NewGuid(), "List 1", 1, Gender.Female, default!);

        _readService.ExistsByNameAsync(command.Name).Returns(true);
        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PackingListAlreadyExistsException>();
    }

    [Fact]
    public async Task HandleAsync_Throws_MissingLocalizationWeatherException_When_WeatherService_Is_Not_Returned()
    {
        var command = new CreatePackingListWithItems(Guid.NewGuid(), "List 1", 1, Gender.Female,
            new LocalizationWriteModel("Warsaw", "Poland"));

        _readService.ExistsByNameAsync(command.Name).Returns(false);
        _weatherService.GetWeatherAsync(Arg.Any<Localization>())!.Returns(default(WeatherDto));

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<MissingLocalizationWeatherException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Repository_On_Success()
    {
        var command = new CreatePackingListWithItems(Guid.NewGuid(), "List 1", 1, Gender.Female,
            new LocalizationWriteModel("Warsaw", "Poland"));

        _readService.ExistsByNameAsync(command.Name).Returns(false);
        _weatherService.GetWeatherAsync(Arg.Any<Localization>())!.Returns(new WeatherDto(15D));
        _factory.CreateWithDefaultValues(command.Id, command.Name, command.Days, Gender.Female, Arg.Any<Temperature>(),
            Arg.Any<Localization>()).Returns(default(PackingList));

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldBeNull();

        await _repository.Received(1).AddAsync(Arg.Any<PackingList>());
    }


    #region ARRANGE

    private readonly ICommandHandler<CreatePackingListWithItems> _commandHandler;
    private readonly IPackingListRepository _repository;
    private readonly IWeatherService _weatherService;
    private readonly IPackingListReadService _readService;
    private readonly IPackingListFactory _factory;

    public CreatePackingListWithItemsHandlerTests()
    {
        _repository = Substitute.For<IPackingListRepository>();
        _weatherService = Substitute.For<IWeatherService>();
        _readService = Substitute.For<IPackingListReadService>();
        _factory = Substitute.For<IPackingListFactory>();

        _commandHandler = new CreatePackingListWithItemsHandler(_repository, _readService, _factory, _weatherService);
    }

    #endregion
}
