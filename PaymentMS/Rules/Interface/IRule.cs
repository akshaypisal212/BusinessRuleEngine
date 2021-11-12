using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleEngine
{
    public interface IRule
    {
        bool IsApplicable(PaymentContext paymentContext);

        String Execute(PaymentContext paymentContext);
    }
}
