using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.Infrastructure;
using Todo.Data.Queries.Sales;
using Todo.Domain.BaseResponse;
using Todo.Domain.Sales;
using Todo.Domain.TodoList;

namespace Todo.Data.Sales
{
    public class HRManagement_Repository : IHRManagement_Repository
    {

        private readonly DapperContext _context;
        public HRManagement_Repository(DapperContext dapper) => _context = dapper;


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

        public async Task<MessageStatus<List<Employee>>> GetByRole(int roleID)
        {
            var response = new MessageStatus<List<Employee>>();
            string sql = "SELECT * FROM [Employee] WHERE [role_id] = @role_id";
            try
            {
                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<Employee>(sql, new { role_id = roleID });

                if (!result.Any())
                {
                    response.success = false;
                    response.message = "Don't have any data";
                }
                else
                {
                    response.success = true;
                    response.data = result.ToList();
                }
                
            }
            catch (Exception ex) {
                response.success = false;
                response.message = ex.Message;
            }

            return response;
        }

        public Task<string> UpdateAsync(MessageStatus<Employee> entity)
        {
            throw new NotImplementedException();
        }
    }
}
