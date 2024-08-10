using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.Sales;

namespace WebManagement.Controllers
{
    public class HRController : Controller
    {
        enum Role
        {
            ADMIN = 1,
            STAFF = 2,
            SHOP = 3,
            CUSTOMER = 4,
        }

        IHRManagement_Repository _hrRepository;
        public HRController(IHRManagement_Repository hrRepository) 
        {
            _hrRepository = hrRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View();
        }

        public async Task<ActionResult> Customers_Read([DataSourceRequest] DataSourceRequest dsrequest)
        {

            var employees = await _hrRepository.GetByRole((int)Role.SHOP);

            // Check If Not Success -> return Error
            if (!employees.success)
            {
                return Json(new DataSourceResult
                {
                    Errors = new[] { employees.message },
                });
            }

            return new JsonResult(employees.data.ToDataSourceResult(dsrequest));
        }

    }
}
