namespace BusinessRuleEngine
{
    public class NewMembership : IRule
    {
        public string Execute(PaymentContext paymentContext)
        {
            return $"{paymentContext.ProductType} activation complete and email has been triggered.";
        }

        public bool IsApplicable(PaymentContext paymentContext)
        {
            if (paymentContext.ProductType == PaymentMS.Enums.ProductType.NEWMEMBERSHIP) return true;
            return false;
        }
    }
}

