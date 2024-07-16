using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.TodoList;
using Todo.Domain.BaseResponse;
using Todo.Domain.TodoList;

namespace MyTodoList.App.Controllers
{
    public class TodoListController : Controller
    {

        private readonly ITodo_Repository _crud;

        public TodoListController(ITodo_Repository crud)
        {
            _crud = crud;
        }

        public IActionResult Index()
        {
            /*throw new Exception("Throw a exception to test");*/
            return View();
        }

        public async Task<string> GetTodoList(int id)
        {
            var rs = await _crud.GetById(id);
            if (!rs.success)
            {
                return rs.message;
            }
            return rs.data.name;
        }

        public async Task<ActionResult> Select([DataSourceRequest] DataSourceRequest dsrequest)
        {

            var rs = await _crud.GetAll();

            // Check If Not Success -> return Error
            if (!rs.success)
            {
                return Json(new DataSourceResult
                {
                    Errors = new[] { rs.message },
                });
            }

            return new JsonResult(rs.data.ToDataSourceResult(dsrequest));
        }

        public async Task<JsonResult> Create([DataSourceRequest] DataSourceRequest dsrequest, TodoModel todo)
        {
            var rs = await _crud.Add(todo);

            // Check If Not Success -> return Error
            if (!rs.success)
            {
                return Json(new DataSourceResult
                {
                    Errors = new[] { rs.message },
                });
            }

            return Json(new[] { todo }.ToDataSourceResult(dsrequest, ModelState));
        }

        public async Task<JsonResult> Update([DataSourceRequest] DataSourceRequest dsrequest, TodoModel todo)
        {

            var rs = await _crud.Update(todo);

            // Check If Not Success -> return Error
            if (!rs.success)
            {
                return Json(new DataSourceResult
                {
                    Errors = new[] { rs.message },
                });
            }

            return Json(new[] { todo }.ToDataSourceResult(dsrequest, ModelState));
        }

        public async Task<JsonResult> Destroy([DataSourceRequest] DataSourceRequest dsrequest, TodoModel todo)
        {
            var rs = await _crud.Remove(todo.id);

            // Check If Not Success -> return Error
            if (!rs.success)
            {
                return Json(new DataSourceResult
                {
                    Errors = new[] { rs.message },
                });
            }

            return Json(new[] { todo }.ToDataSourceResult(dsrequest, ModelState));
        }

    }
}
