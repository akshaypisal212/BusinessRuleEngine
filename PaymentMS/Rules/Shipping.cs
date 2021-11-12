using Microsoft.Extensions.Logging;
using PaymentMS.Enums;

namespace BusinessRuleEngine
{
    public class Shipping : IRule
    {
        public Shipping(ILogger<Shipping> logger)
        {
            this.Logger = logger;
        }

        public ILogger<Shipping> Logger { get; }

        public string Execute(PaymentContext paymentContext)
        {
            this.Logger.LogInformation($"Shipping rule executed for the product segment {0}", paymentContext.ProductSegment.ToString());
            // Will be an call to packaging MS. For simplicity returning string response
            return $"Packaging slip generated for the product {paymentContext.ProductSegment}.";
        }

        public bool IsApplicable(PaymentContext paymentContext)
        {
            //checks if rule is applicable for the selected product
            if (paymentContext.ProductSegment == ProductSegment.PHYSICAL) return true;
            return false;
        }
    }
}