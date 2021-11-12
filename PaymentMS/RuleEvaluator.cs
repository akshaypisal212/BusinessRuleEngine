using System.Collections.Generic;
using System.Linq;
using BusinessRuleEngine;

namespace PaymentMS.Controllers
{
    public class RuleEvaulator
    {
        private readonly IEnumerable<IRule> rules;

        public RuleEvaulator(IEnumerable<IRule> ruleCollection)
        {
            rules = ruleCollection;
        }

        public IEnumerable<string> Execute(PaymentContext ctx)
        {
            // pick up all registered rules and execute applicable rules for the selected product.
            var result = rules
                        .Where(rule => rule.IsApplicable(ctx))
                        .Select(rule => rule.Execute(ctx));

            if (result != null && result.Any())
            {
                return result;
            }

            //when selected product is available but no applicable rule is found for the product, then return null from evaluator
            return null;
        }

    }
}