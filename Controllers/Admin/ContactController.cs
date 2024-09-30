using Microsoft.AspNetCore.Mvc;

namespace amartech.Controllers.Admin
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
