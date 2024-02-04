using System.Text.Json;
using FluentValidation;

namespace Project.WebApi.Middlewares;

public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ValidationExceptionMiddleware> _logger;

    public ValidationExceptionMiddleware(RequestDelegate next, ILogger<ValidationExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ValidationException validationException)
        {
            _logger.LogInformation("ValidationException caught: {ValidationErrors}", validationException.Errors);

            httpContext.Response.StatusCode = 400;
            httpContext.Response.ContentType = "application/json";

            var errors = validationException.Errors.Select(error => new
            {
                PropertyName = error.PropertyName,
                ErrorMessage = error.ErrorMessage
            });

            var jsonResponse = JsonSerializer.Serialize(new { Errors = errors });
            await httpContext.Response.WriteAsync(jsonResponse);

            return;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "An unexpected error occurred.");

            httpContext.Response.StatusCode = 500;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync("An unexpected error occurred.");
        }
    }
}