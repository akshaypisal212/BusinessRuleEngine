using PaymentMS.Controllers;

namespace BusinessRuleEngine
{
    public class PaymentContext
    {
        public PaymentContext(ProductContract productContract)
        {
            ProductType = productContract.productType;
            ProductSegment = productContract.ProductSegment;
            ModeOfPayment = productContract.ModeOfPayment;
            Amount = productContract.Amount;
        }

        public string ProductType { get; set; }

        public string ProductSegment { get; set; }

        public string ModeOfPayment { get; set; }

        public string Amount { get; set; }
    }
}