using Azure.Core;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.TodoList;

namespace MyTodoList.App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser_Repository _repository;

        public UserController(IUser_Repository repository) {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Read([DataSourceRequest] DataSourceRequest dsRequest)
        {
            var result = await _repository.GetAll();

            if (!result.success)
            {
                return Json(new DataSourceResult
                {
                    Errors = new[] { result.message },
                });
            }

            return new JsonResult(result.data.ToDataSourceResult(dsRequest));
        }
    }
}
