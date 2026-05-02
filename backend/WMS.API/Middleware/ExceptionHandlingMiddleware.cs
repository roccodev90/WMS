using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WMS.API.Middleware;

public sealed class ExceptionHandlingMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException vex)
        {
            _logger.LogWarning(vex, "Validazione non riuscita");
            await WriteValidationProblemAsync(context, vex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            await WriteProblemAsync(context, ex);
        }
    }

    private static Task WriteValidationProblemAsync(HttpContext context, ValidationException vex)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        var problem = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validazione non riuscita",
            Detail = string.Join("; ", vex.Errors.Select(e => e.ErrorMessage))
        };

        problem.Extensions["errors"] = vex.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

        return context.Response.WriteAsJsonAsync(problem);
    }

    private static Task WriteProblemAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var problem = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Si è verificato un errore",
            Detail = ex.Message
        };

        return context.Response.WriteAsJsonAsync(problem);
    }
}
