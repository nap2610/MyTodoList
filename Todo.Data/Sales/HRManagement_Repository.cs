using Dapper;
using System.Data;
using Todo.Data.Infrastructure;
using Todo.Data.Queries.Sales;
using Todo.Domain.BaseResponse; 
using Todo.Domain.Sales;
using Todo.Domain.ViewModels;

namespace Todo.Data.Sales
{
    public class HRManagement_Repository : IHRManagement_Repository
    {

        private readonly DapperContext _context;
        public HRManagement_Repository(DapperContext dapper) => _context = dapper;


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

        public async Task<MessageStatus<List<UserViewModel>>> GetAllCustomer()
        {
            var response = new MessageStatus<List<UserViewModel>>();
            string procName = "SelectCustomerWithOrderCount";
            try
            {
                using var connection = _context.CreateConnection();

                /*                Dictionary<int?, User> userDictionary = new Dictionary<int?, User>();
                                var result = await connection.QueryAsync<User, Order, User>(HR.getAllCustomerWithOrder, (user, order) =>
                                {
                                    if (!userDictionary.TryGetValue(user.id, out User userEntry))
                                    {
                                        userEntry = user;
                                        userEntry.Order = new List<Order>();
                                        userDictionary.Add(userEntry.id, userEntry);
                                        userEntry.Order.Add(order);
                                        return userEntry;
                                    }
                                    else
                                    {
                                        userEntry.Order.Add(order);
                                    }
                                    return null;
                                }, splitOn: "id");

                                var trimResult = result.Where(x => x != null).ToList();
                                response.data = trimResult;*/

                /*var result = await connection.QueryAsync<User, Address, User>(sql, (user, address) => { 
                    user.Address = address;
                    return user;
                }, splitOn: "id");*/


                var result = await connection.QueryAsync<UserViewModel>(procName, commandType: CommandType.StoredProcedure);
                response.data = result.ToList();
                response.success = true;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }

            return response;
        }

        public Task<MessageStatus<User>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<MessageStatus<List<User>>> GetByRole(int roleID)
        {
            var response = new MessageStatus<List<User>>();
            string sql = "SELECT * FROM [Employee] WHERE [role_id] = @role_id";
            try
            {
                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<User>(sql, new { role_id = roleID });


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

        public Task<string> UpdateAsync(MessageStatus<User> entity)
        {
            throw new NotImplementedException();
        }
    }
}
