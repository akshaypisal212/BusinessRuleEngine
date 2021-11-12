using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaymentMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public PaymentController()
        {
        }

        [Route("/ProcessPayment")]
        [HttpPost]
        public IActionResult ProcessPayment([FromBody] ProductContract productContract)
        {
            return Ok();
        }
    }
}
