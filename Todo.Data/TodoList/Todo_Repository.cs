using Dapper.Contrib.Extensions;
using System.Threading.Tasks;
using Todo.Domain.BaseResponse;
using Todo.Domain.TodoList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Todo.Data.TodoList
{
    public class Todo_Repository : ITodo_Repository
    {

        private readonly DapperContext _context;

        public Todo_Repository(DapperContext dapper) => _context = dapper;

        public async Task<MessageStatus<long>> Add(TodoModel entity)
        {
            /*var query = "INSERT INTO TodoList (name, [desc], due_date, done) VALUES (@Name, @Desc, @due_date, @Done)";*/
            /*var result = await connection.ExecuteAsync(query, new { entity.name, entity.desc, entity.due_date, entity.done });
                return result;*/

            var response = new MessageStatus<long>();

            try
            {
                using var connection = _context.CreateConnection();
                // Ném 1 lỗi để test
                /*throw new Exception("- ERROR: Insert fail at TodoList.Todo_Repository can not casting TodoListModel...");*/
                // Dapper Contrib INSERT
                var todo = await connection.InsertAsync(new TodoModel
                {
                    id = 0,
                    name = entity.name,
                    desc = entity.desc,
                    due_date = entity.due_date,
                    done = entity.done
                });

                response.success = true;
                response.data = todo;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }

            return response;
        }

        public async Task<MessageStatus<List<TodoModel>>> GetAll()
        {
            /*var query = "SELECT * FROM Task";*/
            /*var tasks = await connection.QueryAsync<Tasks>(query);
                return tasks.ToList();*/

            var response = new MessageStatus<List<TodoModel>>();

            try
            {
                using var connection = _context.CreateConnection();
                // Dapper Contrib GetAll
                var result = await connection.GetAllAsync<TodoModel>();

                //set success false nếu không có exception
                response.success = true;
                response.data = result.ToList();

                // Ném 1 lỗi để test
                /*throw new Exception("- ERROR: can not read data from MessageStatus<List<TodoListModel>>...");*/
            }
            catch (Exception ex)
            {
                //set success true khi có exception
                response.success = false;
                response.message = ex.Message;
            }

            return response; // Trả về kiểu MessageStatus<List<TodoListModel>>()
        }

        public async Task<MessageStatus<TodoModel>> GetById(int id)
        {
            /*var query = "SELECT * FROM Task WHERE id = @Id";*/
            /*var task = await connection.QuerySingleOrDefaultAsync<Tasks>(query, new { Id = id });*/

            var response = new MessageStatus<TodoModel>();

            try
            {
                using var connection = _context.CreateConnection();
                // Dapper Contrib Get
                var todo = await connection.GetAsync<TodoModel>(id);

                response.success = true;
                response.data = todo;

                if (todo == null)
                {
                    throw new InvalidOperationException($"User with Id {id} not found.");
                }
            }
            catch (Exception ex)
            {
                //set success true khi có exception
                response.success = false;
                response.message = ex.Message;
            }

            return response;
        }

        public async Task<MessageStatus<bool>> Remove(int id)
        {
            /*var query = "DELETE FROM Task WHERE id = @Id";*/
            /*var result = await connection.ExecuteAsync(query, new { Id = id });
                return result;*/

            var response = new MessageStatus<bool>();

            try
            {
                using var connection = _context.CreateConnection();
                // Dapper Contrib DELETE
                var todo = await connection.DeleteAsync(new TodoModel { id = id });

                response.success = true;
                response.data = todo;
            }catch(Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }
            
            return response;
        }

        public async Task<MessageStatus<bool>> Update(TodoModel entity)
        {
            /* var query = "UPDATE Task SET name = @Name, [desc] = @Desc, due_date = @due_date, done = @Done WHERE Id = @Id";*/
            /* var result = await connection.ExecuteAsync(query, new { entity.name, entity.desc, entity.due_date, entity.done, entity.id });
                  return result;*/

            var response = new MessageStatus<bool>();
                
            try
            {
                using var connection = _context.CreateConnection();
                // Dapper Contrib UPDATE
                var todo = await connection.UpdateAsync(entity);

                response.success = true;
                response.data = todo;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }

            return response;
        }
    
    }
}

