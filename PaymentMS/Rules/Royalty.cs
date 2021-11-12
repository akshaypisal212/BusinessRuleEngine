using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (paymentContext.ProductType.ToUpper() == "BOOK") return true;
            return false;
        }
    }
}
