using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Todo.Data.CustomErrorHandling;

namespace MyTodoList.App.ErrorHandling
{

    public class GlobalExceptionHandler
        ( ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {


        public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
        {

            var problemDetails = new ProblemDetails();
            problemDetails.Instance = httpContext.Request.Path;
            if (exception is BaseException e)
            {
                httpContext.Response.StatusCode = (int)e.StatusCode;
                problemDetails.Title = e.Message;
            }
            else
            {
                problemDetails.Title = exception.Message;
            }
            logger.LogError("{ProblemDetailsTitle}", problemDetails.Title);
            problemDetails.Status = httpContext.Response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);
            return true;


        }

    }
}

//Separate Global Exception

/*public class ProductNotFoundExceptionHandler(ILogger<ProductNotFoundExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ProductNotFoundException e)
        {
            return false;
        }

        //handle error

        return true;
    }
}

//config in program
builder.Services.AddExceptionHandler<ProductNotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<StockExhaustedExceptionHandler>();*/
