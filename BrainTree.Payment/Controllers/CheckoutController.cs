using BrainTree.Payment.Data.Context;
using BrainTree.Payment.Data.Services.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainTree.Payment.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IBraintreeService _braintreeService;
        private readonly AppDbContext _appDbContext;
        public CheckoutController(IBraintreeService braintreeService, AppDbContext appDbContext)
        {
            _braintreeService = braintreeService;
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Purchase(int id)
        {
            var gateway = _braintreeService.GetGateway();
            var clientToken = await gateway.ClientToken.GenerateAsync();
            ViewBag.ClientToken = clientToken;
            return View();
        }
    }
}
