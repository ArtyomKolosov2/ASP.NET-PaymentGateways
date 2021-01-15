using Braintree;
using BrainTree.Payment.Data.Context;
using BrainTree.Payment.Data.Models;
using BrainTree.Payment.Data.Services.Base;
using BrainTree.Payment.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public async Task<IActionResult> Purchase(int id)
        {
            var car = await _appDbContext.Cars.Include("Category").FirstOrDefaultAsync(c => c.Id == id);
            if (car is not null)
            {
                var gateway = _braintreeService.GetGateway();
                var clientToken = await gateway.ClientToken.GenerateAsync();
                var viewModel = new CarPurchaseViewModel
                {
                    ImageUrl = car.ImageURL,
                    Title = "Purchase",
                    Category = car.Category,
                    Price = car.Price,
                    Nonce = string.Empty,

                };
                ViewBag.ClientToken = clientToken;
                return View(viewModel);
            }
            return NoContent();
        }
        public async Task<IActionResult> Create(CarPurchaseViewModel viewModel)
        {
            var gateway = _braintreeService.GetGateway();
            var car = await _appDbContext.Cars.Include("Category").FirstOrDefaultAsync(c => c.Id == viewModel.Id);
            if (car is not null)
            {
                var request = new TransactionRequest
                {
                    Amount = Convert.ToDecimal(car.Price),
                    PaymentMethodNonce = viewModel.Nonce,
                    Options = new TransactionOptionsRequest
                    {
                        SubmitForSettlement = true,
                    }
                };
                Result<Transaction> result = await gateway.Transaction.SaleAsync(request);
                if (result.IsSuccess())
                {
                    return View("Success");
                }
            }
            return View("Failrue");
        }
    }
}
