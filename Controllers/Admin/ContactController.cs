using amartech.Models.Admin;
using amartech.Repositories;
using amartech.Services;
using Microsoft.AspNetCore.Mvc;

namespace amartech.Controllers.Admin
{
    public class ContactController : Controller
    {
        private readonly ContactUsRepository _repository;
        private readonly WhatsAppService _whatsAppService;

        public ContactController(ContactUsRepository repository, WhatsAppService whatsAppService)
        {
            _repository = repository;
            _whatsAppService = whatsAppService;
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

            string message = $"*New Contact Form Submission*\n\n*Name:* {contact.Name}\n*Mobile:* {contact.Mobile}\n*Subject:* {contact.Subject}\n*Message:* {contact.Message}";

            await _whatsAppService.SendContactUsWhatsAppMessage(message);

            return RedirectToAction("Index");
        }
    }
}
