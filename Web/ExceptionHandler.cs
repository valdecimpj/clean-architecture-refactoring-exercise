using Application.Repository;
using Domain.Exceptions;

namespace Web;

public class ExceptionHandlerMiddleware(ISessionLogRepository sessionLogRepository) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (BadUserInputException exception)
        {
            await HandleBadRequestException(context, exception);
        }
    }

    private async Task HandleBadRequestException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(
            new { exception.Message, Logs = await sessionLogRepository.GetForSession() }
        );
    }
}
