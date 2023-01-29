using System.Net;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;


    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, string error, string message = "system error")
    {
        var status = (long)HttpStatusCode.BadRequest;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        return context.Response.WriteAsync(new MessageHelper(message, error).ToString());
    }
}
