using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PaymentMS.Enums;

namespace BusinessRuleEngine
{
    public class Royalty : IRule
    {
        public Royalty(ILogger<Royalty> logger)
        {
            Logger = logger;
        }

        public ILogger<Royalty> Logger { get; }

        public string Execute(PaymentContext paymentContext)
        {
            this.Logger.LogInformation($"Royalty rule executed for the product type {0}", paymentContext.ProductType.ToString());
            return $"Royalty packaging slip generated for the product {paymentContext.ProductType}.";
        }

        public bool IsApplicable(PaymentContext paymentContext)
        {
            if (paymentContext.ProductType == ProductType.BOOK) return true;
            return false;
        }
    }
}
