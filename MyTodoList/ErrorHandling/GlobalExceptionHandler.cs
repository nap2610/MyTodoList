using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace MyTodoList.App.ErrorHandling
{

    public class GlobalExceptionHandler
        (IHostEnvironment hostEnvironment, ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            context.Response.ContentType = "application/json";

            var handleException = context.Features.Get<IExceptionHandlerFeature>();

            if (handleException != null)
            {
                var message = $"{handleException.Error.Message}";
                await context.Response.WriteAsync(message).ConfigureAwait(false);
            }

            return true;

            
        }

    }
}
