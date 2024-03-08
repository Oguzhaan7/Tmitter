using FluentValidation;
using MediatR;

namespace Tmitter.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .Select(error => error.ErrorMessage)
            .ToList();

        if (failures.Any())
            throw new Tmitter.Application.Common.Exceptions.ValidationException(failures);
        
        return await next();
    }
}
