using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.Infrastructure;
using Todo.Domain.BaseResponse;
using Todo.Domain.Sales;

namespace Todo.Data.Sales
{
    public class Auth_Repository : IAuth_Repository
    {
        private readonly DapperContext _context;
        public Auth_Repository(DapperContext dapper) => _context = dapper;

        public Task<string> AddAsync(MessageStatus<User> entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<MessageStatus<User>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MessageStatus<User>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<MessageStatus<User>> CheckLogin(User emp)
        {
            var response = new MessageStatus<User>();
            string sqlUserName = "SELECT * FROM [Employee] WHERE [user_name] = @user";
            try
            {
                using var connection = _context.CreateConnection();
                var checkUserName = await connection.QuerySingleOrDefaultAsync<User>(sqlUserName, new { user = emp.user_name });

                if (checkUserName != null)
                {
                    if (checkUserName.password == emp.password)
                    {
                        response.data = checkUserName;
                        response.success = true;
                    }
                }
                else
                {
                    response.success = false;
                    response.message = "Username Or Password is wrong, Please try again!";
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }

        public Task<string> UpdateAsync(MessageStatus<User> entity)
        {
            throw new NotImplementedException();
        }
    }
}
