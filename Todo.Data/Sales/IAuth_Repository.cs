
using Todo.Data.Infrastructure;
using Todo.Domain.BaseResponse;
using Todo.Domain.Sales;

namespace Todo.Data.Sales
{
    public interface IAuth_Repository : IRepository<MessageStatus<Employee>>
    {
        Task<MessageStatus<Employee>> Login(Employee employee); 
    }
}
