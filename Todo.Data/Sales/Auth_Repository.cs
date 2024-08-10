using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.BaseResponse;
using Todo.Domain.Sales;

namespace Todo.Data.Sales
{
    public class Auth_Repository : IAuth_Repository
    {
        public Task<string> AddAsync(MessageStatus<Employee> entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<MessageStatus<Employee>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MessageStatus<Employee>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageStatus<Employee>> Login(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(MessageStatus<Employee> entity)
        {
            throw new NotImplementedException();
        }
    }
}
