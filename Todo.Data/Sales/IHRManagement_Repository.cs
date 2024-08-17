
using Todo.Data.Infrastructure;
using Todo.Domain.BaseResponse;
using Todo.Domain.Sales;
using Todo.Domain.ViewModels;

namespace Todo.Data.Sales
{
    public interface IHRManagement_Repository : IRepository<MessageStatus<User>>
    {
        Task<MessageStatus<List<User>>> GetByRole(int roleID);
        Task<MessageStatus<List<UserViewModel>>> GetAllCustomer();
    }
}
