using Microsoft.AspNetCore.Mvc;

namespace amartech.Controllers.Admin
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
