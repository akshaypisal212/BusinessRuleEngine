using System.Collections.Generic;
using System.Linq;
using BusinessRuleEngine;

public class RuleEvaulator
{
    private readonly IEnumerable<IRule> rules;

    public RuleEvaulator(IEnumerable<IRule> ruleCollection)
    {
        rules = ruleCollection;
    }

    public IEnumerable<string> Execute(PaymentContext ctx)
    {
        var result = rules
                    .Where(rule => rule.IsApplicable(ctx))
                    .Select(rule => rule.Execute(ctx));

        if (result != null && result.Any())
        {
            return result;
        }
        return null;
    }

}