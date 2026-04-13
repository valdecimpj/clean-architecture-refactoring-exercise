using Microsoft.AspNetCore.Diagnostics;

namespace Web;

public class ExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ArgumentException exception)
        {
            await HandleBadRequestException(context, exception);
        }
        catch (InvalidOperationException exception)
        {
            await HandleBadRequestException(context, exception);
        }
    }

    private Task HandleBadRequestException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsJsonAsync(new { exception.Message });
    }
}
