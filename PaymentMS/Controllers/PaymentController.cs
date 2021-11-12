using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessRuleEngine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaymentMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public PaymentController(IEnumerable<IRule> rule)
        {
            Rules = rule;
        }

        public IEnumerable<IRule> Rules { get; }

        [Route("/ProcessPayment")]
        [HttpPost]
        public IActionResult ProcessPayment([FromBody] ProductContract productContract)
        {

            PaymentContext ctx = new PaymentContext(productContract);

            //check if rule is applicable and execute it one by one
          
            var resultCollection = new RuleEvaulator(Rules).Execute(ctx);

            if (resultCollection == null)
                return Ok("No Applicable Rules Found To Execute");

            return Ok(resultCollection);
            
        }
    }
}
