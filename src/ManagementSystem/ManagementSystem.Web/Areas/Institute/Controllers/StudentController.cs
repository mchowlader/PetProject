using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Web.Areas.Institute.Controllers
{
    [Area("Institute")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
