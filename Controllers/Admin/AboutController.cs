using Microsoft.AspNetCore.Mvc;

namespace amartech.Controllers.Admin
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
