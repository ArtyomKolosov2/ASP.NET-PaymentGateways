using Braintree;
using BrainTree.Payment.Data.Services.Base;
using Microsoft.Extensions.Configuration;

namespace BrainTree.Payment.Data.Services
{
    public class BraintreeService : IBraintreeService
    {
        private readonly IConfiguration _configuration;
        public BraintreeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IBraintreeGateway CreateGateway()
        {
            var section = _configuration.GetSection("BraintTreeGateway");
            var newGateway = new BraintreeGateway()
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = section["MerchantId"],
                PublicKey = section["PublicKey"],
                PrivateKey = section["PrivateKey"]
            };
            return newGateway;
        }

        public IBraintreeGateway GetGateway()
        {
            return CreateGateway();
        }
    }
}
