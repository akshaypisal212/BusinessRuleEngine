using System;
using PaymentMS.Controllers;
using PaymentMS.Enums;

namespace BusinessRuleEngine
{
    public class PaymentContext
    {
        public PaymentContext(ProductContract productContract)
        {
            ProductType = (ProductType)Enum.Parse(typeof(ProductType), productContract.productType, true);
            ProductSegment = (ProductSegment)Enum.Parse(typeof(ProductSegment), productContract.ProductSegment, true);
            ModeOfPayment = (ModeOfPayment)Enum.Parse(typeof(ModeOfPayment), productContract.ModeOfPayment, true);
            Amount = productContract.Amount;
        }

        public ProductType ProductType { get; set; }

        public ProductSegment ProductSegment { get; set; }

        public ModeOfPayment ModeOfPayment { get; set; }

        public string Amount { get; set; }
    }
}