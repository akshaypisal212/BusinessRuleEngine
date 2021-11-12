using PaymentMS.Enums;

namespace BusinessRuleEngine
{
    public class Shipping : IRule
    {
        public string Execute(PaymentContext paymentContext)
        {
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