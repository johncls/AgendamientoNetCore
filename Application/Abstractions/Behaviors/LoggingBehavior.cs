using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Abstractions.Behaviors
{
    public class Loggingbehavior<TRequest, TResposse> : IPipelineBehavior<TRequest, TResposse> where TRequest : IBaseCommand
{
    private const string Message = "Ejecuntando el comando request:";
    private readonly ILogger<TRequest> _logger;

    public Loggingbehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }
    public async Task<TResposse> Handle(TRequest request, RequestHandlerDelegate<TResposse> next, CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation(Message, $"{name}");

            var result = await next();

            _logger.LogInformation("El comando se ejecuto exitosamente", $"{name}");

            return result;
        }
        catch (ValidationException ex)
        {
            _logger.LogError(ex, $"el comando tuvo errores");

            throw new (ex.ValidationResult.ErrorMessage);
        }
    }
}
}