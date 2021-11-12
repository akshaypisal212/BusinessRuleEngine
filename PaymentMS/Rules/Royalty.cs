using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentMS.Enums;

namespace BusinessRuleEngine
{
    public class Royalty : IRule
    {
        public string Execute(PaymentContext paymentContext)
        {
            return $"Royalty packaging slip generated for the product {paymentContext.ProductType}.";
        }

        public bool IsApplicable(PaymentContext paymentContext)
        {
            if (paymentContext.ProductType == ProductType.BOOK) return true;
            return false;
        }
    }
}
