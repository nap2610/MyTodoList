using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;
using Todo.Data.Sales;

namespace MyTodoList.App.Controllers
{
    public class SalesController : Controller
    {
        public enum Role
        {
            admin = 1,
            staff =2,
            shop = 3,
            member = 4,
            normal = 5,
        }

        IHRManagement_Repository _hrRepository;
        IPackageManagement_Repository _pmRepository;

        public SalesController(IHRManagement_Repository hrRepository, IPackageManagement_Repository pmRepository)
        {
            _hrRepository = hrRepository;
            _pmRepository = pmRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HRInformation()
        {
            return View();
        }

        public IActionResult PackageInformation()
        {
            return View();
        }

    }
}
