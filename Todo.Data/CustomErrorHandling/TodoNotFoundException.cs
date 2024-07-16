using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Data.CustomErrorHandling
{
    public class TodoNotFoundException : BaseException
    {
        public TodoNotFoundException(int id)
        : base($"TodoList with id {id} not found", HttpStatusCode.NotFound)
        {
        }
    }
}
