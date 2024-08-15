
using Todo.Data.Infrastructure;
using Todo.Domain.BaseResponse;
using Todo.Domain.Sales;

namespace Todo.Data.Sales
{
    public interface IAuth_Repository : IRepository<MessageStatus<User>>
    {
        Task<MessageStatus<User>> CheckLogin(User emp);
    }
}
