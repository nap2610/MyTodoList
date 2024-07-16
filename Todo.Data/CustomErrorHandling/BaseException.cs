
using System.Net;


namespace Todo.Data.CustomErrorHandling
{
    public class BaseException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
