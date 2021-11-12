
namespace BusinessRuleEngine
{
    public class MembershipUpgrade : IRule
    {
        public string Execute(PaymentContext paymentContext)
        {
            return $"Membership upgrade is complete and mail has been triggered.";
        }

        public bool IsApplicable(PaymentContext paymentContext)
        {
            if (paymentContext.ProductType == PaymentMS.Enums.ProductType.UPGRADEMEMBERSHIP) return true;
            return false;
        }
    }
}
