﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.Sales;
using Todo.Domain.Sales;
using Todo.Domain.ViewModels;
using static Slapper.AutoMapper;

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
        enum Active
        {
            DISABLE = 0,
            ACTIVE = 1,
        }
        IAuth_Repository _authRepository;
        IHRManagement_Repository _hrRepository;
        public HRController(IHRManagement_Repository hrRepository, IAuth_Repository auth_Repository) 
        {
            _hrRepository = hrRepository;
            _authRepository = auth_Repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User emp)
        {
            var loginResult = await _authRepository.CheckLogin(emp);

            if (loginResult.success)
            {
                HttpContext.Session.SetInt32("Role", emp.role_id);
                return View("Customer");
            }

            return View("Index");
        }


        public IActionResult Customer(int id)
        {
            if (id > 0)
            {
                ViewBag.Id = id;
            }
            return View();
        }

        public IActionResult Staff()
        {
            return View();
        }

        public async Task<ActionResult> Customers_Read([DataSourceRequest] DataSourceRequest dsrequest, string id)
        {
            var customers = await _hrRepository.GetAllCustomer();

            // Check If Not Success -> return Error
            if (!customers.success)
            {
                return Json(new DataSourceResult
                {
                    Errors = new[] { customers.message },
                });
            }

            IEnumerable<UserViewModel> result = customers.data;

            if (!string.IsNullOrEmpty(id))
            {
                result = result.Where(p => p.user_id.Equals( int.Parse(id) ));
            }

            return new JsonResult(result.ToDataSourceResult(dsrequest));
        }

        public async Task<ActionResult> Staffs_Read([DataSourceRequest] DataSourceRequest dsrequest)
        {

            var employees = await _hrRepository.GetByRole((int)Role.STAFF);

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
