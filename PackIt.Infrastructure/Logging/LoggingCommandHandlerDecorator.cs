﻿using Microsoft.Extensions.Logging;
using PackIt.Shared.Abstractions.Commands;
using System.Data;

namespace PackIt.Infrastructure.Logging;

internal sealed class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
{
    private readonly ICommandHandler<TCommand> _commandHandler;
    private readonly ILogger<LoggingCommandHandlerDecorator<TCommand>> _logger;

    public LoggingCommandHandlerDecorator(
        ILogger<LoggingCommandHandlerDecorator<TCommand>> logger,
        ICommandHandler<TCommand> commandHandler)
    {
        _logger = logger;
        _commandHandler = commandHandler;
    }

    public async Task HandleAsync(TCommand command)
    {
        var commandType = command.GetType().Name;

        try
        {
            _logger.LogInformation($"Started processing {commandType} command");
            await _commandHandler.HandleAsync(command);
            _logger.LogInformation($"Finished processing {commandType} command");
        }
        catch (Exception)
        {
            _logger.LogError($"Failed to process {commandType} command");
            throw;
        }
    }
}
