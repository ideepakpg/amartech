using amartech.Models.Admin;
using amartech.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace amartech.Controllers.Admin
{
    public class ContactController : Controller
    {
        private readonly ContactUsRepository _repository;

        public ContactController(ContactUsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitContactUs([FromBody] ContactUs contact)
        {
            contact.CreatedBy = contact.Name;
            await _repository.InsertContactUsAsync(contact);
            return RedirectToAction("Index");
        }
    }
}
