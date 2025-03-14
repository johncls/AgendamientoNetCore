using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Abstractions.Behaviors
{
    public class ValidationBehavior<TRequest, TResposse> : IPipelineBehavior<TRequest, TResposse> where TRequest : IBaseCommand
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validotors)
    {
        _validators = validotors;
    }

    public async Task<TResposse> Handle(TRequest request, RequestHandlerDelegate<TResposse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationErrors = _validators.Select(validators => validators.Validate(context))
            .Where(validationsResult => validationsResult.Errors.Any())
            .SelectMany(validationsResult => validationsResult.Errors)
            .Select(validationFailure => new ValidateError(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage
             )).ToList();

        if (validationErrors.Any())
        {
            throw new Exceptions.ValidationException(validationErrors);
        }

        return await next();
    }
}
}