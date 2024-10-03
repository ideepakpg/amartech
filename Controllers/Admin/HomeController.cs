using amartech.Repositories;
using Microsoft.AspNetCore.Mvc;
using amartech.Models.Admin;
using amartech.Services;

namespace amartech.Controllers.Admin
{
    public class HomeController : Controller
    {
        private readonly RequestPricingRepository _repository;
        private readonly WhatsAppService _whatsAppService;

        public HomeController(RequestPricingRepository repository, WhatsAppService whatsAppService)
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
        public async Task<IActionResult> SubmitPricingRequest([FromBody] PricingRequest request)
        {
            request.CreatedBy = request.Name;
            await _repository.InsertPricingRequestAsync(request);

            string message = $"*New Pricing Request Submission*\n\n*Name:* {request.Name}\n*Email:* {request.Email}\n*Mobile:* {request.Mobile}\n*Service:* {request.Service}\n*Special Note:* {request.SpecialNote}";

            await _whatsAppService.SendPricingRequestWhatsAppMessageAsync(message);

            return RedirectToAction("Index");
        }
    }
}
