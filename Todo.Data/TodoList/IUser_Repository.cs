using Todo.Domain.BaseResponse;
using Todo.Domain.TodoList;

namespace Todo.Data.TodoList
{
    public interface IUser_Repository
    {
        Task<MessageStatus<Account>> GetById(int id);
        Task<MessageStatus<List<Account>>> GetAll();
        Task<MessageStatus<long>> Add(Account entity);
        Task<MessageStatus<bool>> Update(Account entity);
        Task<MessageStatus<bool>> Remove(int id);
    }
}
