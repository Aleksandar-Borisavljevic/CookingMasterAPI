
using CookingMasterApi.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (NotFoundException ex)
        {
           await HandleNotFoundException(httpContext, ex);
        }
        catch (ValidationException ex)
        {
            await HandleValidationException(httpContext, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var details = new ProblemDetails()
        {
            Type = "InternalServerError",
            Title = "InternalServerError",
            Detail = exception.Message,
            Status = (int)HttpStatusCode.InternalServerError
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(details));
    }

    private async Task HandleNotFoundException(HttpContext context, NotFoundException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;

        var details = new ProblemDetails()
        {
            Type = "NotFound",
            Title = "The specified resource was not found.",
            Detail = exception.Message,
            Status = (int)HttpStatusCode.NotFound
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(details));
    }

    private async Task HandleValidationException(HttpContext context, ValidationException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        foreach (var error in exception.Errors)
        {
            _logger.LogError(exception, string.Join(",", error.Value));
        }

        var details = new ValidationProblemDetails(exception.Errors)
        {
            Type = "ValidationException",
            Detail = exception.Message,
            Status = (int)HttpStatusCode.BadRequest
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(details));
    }




}
