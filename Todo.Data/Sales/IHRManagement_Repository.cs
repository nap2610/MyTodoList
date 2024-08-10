
using Todo.Data.Infrastructure;
using Todo.Domain.BaseResponse;
using Todo.Domain.Sales;

namespace Todo.Data.Sales
{
    public interface IHRManagement_Repository : IRepository<MessageStatus<Employee>>
    {
        Task<MessageStatus<List<Employee>>> GetByRole(int roleID);
    }
}
