
namespace Todo.Domain.BaseResponse
{
    public class MessageStatus<T>
    {
        public T? data { get; set; }
        public string? message { get; set; }
        public bool success { get; set; }
    }
}
