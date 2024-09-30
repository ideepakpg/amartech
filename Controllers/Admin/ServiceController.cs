using Microsoft.AspNetCore.Mvc;

namespace amartech.Controllers.Admin
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
