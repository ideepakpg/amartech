using Microsoft.AspNetCore.Mvc;

namespace amartech.Controllers.Admin
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
