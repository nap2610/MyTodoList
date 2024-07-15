using Dapper.Contrib.Extensions;
using Todo.Data.Infrastructure;
using Todo.Domain.BaseResponse;
using Todo.Domain.TodoList;

namespace Todo.Data.TodoList
{
    public class User_Repository : IUser_Repository
    {

        private readonly DapperContext _context;
        public User_Repository(DapperContext context) {
            _context = context;
        }

        public Task<MessageStatus<long>> Add(Account entity)
        {
            throw new NotImplementedException();
        }

        public async Task<MessageStatus<List<Account>>> GetAll()
        {
            var response = new MessageStatus<List<Account>>();

            try
            {
                using var connection = _context.CreateConnection();
                // Dapper Contrib GetAll
                var result = await connection.GetAllAsync<Account>();

                //set success false nếu không có exception
                response.success = true;
                response.data = result.ToList();

                // Ném 1 lỗi để test
                /*throw new Exception("- ERROR: can not read data from MessageStatus<List<User>>...");*/
            }
            catch (Exception ex)
            {
                //set success true khi có exception
                response.success = false;
                response.message = ex.Message;
            }

            return response; // Trả về kiểu MessageStatus<List<User>>()
        }

        public Task<MessageStatus<Account>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageStatus<bool>> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageStatus<bool>> Update(Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
