namespace BusinessRuleEngine
{
    public class AgentCommission : IRule
    {
        public string Execute(PaymentContext paymentContext)
        {
            return $"A commission payment to the agent has been generated.";
        }

        public bool IsApplicable(PaymentContext paymentContext)
        {
            if (paymentContext.ProductSegment == PaymentMS.Enums.ProductSegment.PHYSICAL
                || paymentContext.ProductType == PaymentMS.Enums.ProductType.BOOK) return true;
            return false;
        }
    }
}
