using Todo.Domain.BaseResponse;
using Todo.Domain.TodoList;

namespace Todo.Data.TodoList
{
    public interface ITodo_Repository
    {
        Task<MessageStatus<TodoModel>> GetById(int id);
        Task<MessageStatus<List<TodoModel>>> GetAll();
        Task<MessageStatus<long>> Add(TodoModel entity);
        Task<MessageStatus<bool>> Update(TodoModel entity);
        Task<MessageStatus<bool>> Remove(int id);
    }
}
