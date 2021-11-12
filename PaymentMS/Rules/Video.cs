namespace BusinessRuleEngine
{
    public class Video : IRule
    {
        public string Execute(PaymentContext paymentContext)
        {
            return $"A free “First Aid” video has been added to the packing slip.";
        }

        public bool IsApplicable(PaymentContext paymentContext)
        {
            if (paymentContext.ProductType == PaymentMS.Enums.ProductType.VIDEO) return true;
            return false;
        }
    }
}
