using System.Diagnostics;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Tmitter.Application.Common.Utils;

namespace Tmitter.Application.Common.Behaviors;

public sealed class
    ExceptionBehavior<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TResponse : Result, new()
    where TException : Exception
{
    private readonly ILogger<ExceptionBehavior<TRequest, TResponse, TException>> _logger;

    public ExceptionBehavior(ILogger<ExceptionBehavior<TRequest, TResponse, TException>> logger)
    {
        _logger = logger;
    }

    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
        CancellationToken cancellationToken)
    {
        var ex = exception.Demystify();

        _logger.LogError(ex, "Something went wrong while handling request of type {@requestType}", typeof(TRequest));

        var response = new TResponse
        {
            Code = 500,
            Succeeded = false,
            Message = "Server error occured"
        };

        state.SetHandled(response);

        return Task.CompletedTask;
    }
}