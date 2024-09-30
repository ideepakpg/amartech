using Microsoft.AspNetCore.Mvc;

namespace amartech.Controllers.Admin
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
