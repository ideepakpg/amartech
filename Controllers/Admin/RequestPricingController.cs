using Microsoft.AspNetCore.Mvc;
using amartech.Repositories;
using amartech.Models.Admin;
using amartech.Services;

namespace amartech.Controllers.Admin
{
    public class RequestPricingController : Controller
    {
        private readonly RequestPricingRepository _repository;
        private readonly WhatsAppService _whatsAppService;

        public RequestPricingController(RequestPricingRepository repository, WhatsAppService whatsAppService)
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
        public async Task<IActionResult> SubmitRequestPricing([FromBody] PricingRequest request)
        {
            request.CreatedBy = request.Name;
            await _repository.InsertPricingRequestAsync(request);

            string message = $"*New Pricing Request Submission*\n\n*Name:* {request.Name}\n*Email:* {request.Email}\n*Mobile:* {request.Mobile}\n*Service:* {request.Service}\n*Special Note:* {request.SpecialNote}";

            await _whatsAppService.SendPricingRequestWhatsAppMessageAsync(message);

            return RedirectToAction("Index");
        }
    }
}
