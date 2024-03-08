using FluentValidation;
using System.IdentityModel;
using System.Text.Json;
using FluentValidation.Results;
using Tmitter.Application.Common.Exceptions;

namespace Tmitter.Api.Middleware;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = GetStatusCode(exception);

        var response = new
        {
            title = GetTitle(exception),
            status = statusCode,
            detail = exception.Message,
            errors = GetErrors(exception)
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            Application.Common.Exceptions.ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };
    }

    private static string GetTitle(Exception exception)
    {
        return exception switch
        {
            TmitterException tmitterException => tmitterException.Title,
            _ => "Server Error"
        };
    }

    private static List<string> GetErrors(Exception exception)
    {
        List<string> errors = new();

        if (exception is Application.Common.Exceptions.ValidationException validationException)
        {
            errors = validationException.Errors;
        }

        return errors;
    }
}