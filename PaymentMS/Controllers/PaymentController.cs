using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessRuleEngine;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PaymentMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public PaymentController(IEnumerable<IRule> rule, ILogger<PaymentController> logger)
        {
            this.Rules = rule;
            this.Logger = logger;
        }

        public IEnumerable<IRule> Rules { get; }
        public ILogger<PaymentController> Logger { get; }

        [Route("/ProcessPayment")]
        [HttpPost]
        public IActionResult ProcessPayment([FromBody] ProductContract productContract)
        {
            PaymentContext ctx;

            try
            {
                ctx = new PaymentContext(productContract);
            }
            catch (Exception ce)
            {
                this.Logger.LogError(ce.Message, ce.StackTrace);
                return BadRequest();
            }
            
            //check if rule is applicable and execute it one by one
          
            var resultCollection = new RuleEvaulator(Rules).Execute(ctx);

            if (resultCollection == null)
                return Ok("No Applicable Rules Found To Execute");

            return Ok(resultCollection);
            
        }
    }
}
