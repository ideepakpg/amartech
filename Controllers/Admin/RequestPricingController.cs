using Microsoft.AspNetCore.Mvc;
using amartech.Repositories;
using amartech.Models.Admin;

namespace amartech.Controllers.Admin
{
    public class RequestPricingController : Controller
    {
        private readonly RequestPricingRepository _repository;

        public RequestPricingController(RequestPricingRepository repository)
        {
            _repository = repository;
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
            return RedirectToAction("Index");
        }
    }
}
