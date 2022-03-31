using Autofac;
using ManagementSystem.Web.Areas.Institute.Models.StudentModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ManagementSystem.Web.Areas.Institute.Controllers
{
    [Area("Institute")]
    public class StudentController : Controller
    {
        private ILifetimeScope _scope;
        public StudentController(ILifetimeScope scope)
        {
            _scope = scope;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
