﻿using amartech.Repositories;
using Microsoft.AspNetCore.Mvc;
using amartech.Models.Admin;

namespace amartech.Controllers.Admin
{
    public class HomeController : Controller
    {
        private readonly RequestPricingRepository _repository;

        public HomeController(RequestPricingRepository repository)
        {
            _repository = repository;
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
            return RedirectToAction("Index");
        }
    }
}
