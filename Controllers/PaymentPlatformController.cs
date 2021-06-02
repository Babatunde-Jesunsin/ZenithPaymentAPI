using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PayCore.DTO.ViewModel;
using PayCore.Manager;

namespace PayAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentPlatformController : ControllerBase
    {
        private readonly ILogger<PaymentPlatformController> _logger;
        private readonly IPaymentManager _paymentManager;

        public PaymentPlatformController(ILogger<PaymentPlatformController> logger, IPaymentManager paymentManager)
        {
            _logger = logger;
            _paymentManager = paymentManager;
        }
       
        [HttpPost]
        public async Task<IActionResult> ProcessPaymentAsyc(PaymentRequest model)
        {
            try
            {
                return Ok(await _paymentManager.MakePayment(model));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
            

        }

   
        [HttpGet]
        public async Task<IActionResult> QueryPaymentAsync(Guid payRef)
        {
            try
            {
                return Ok(await _paymentManager.GetPayment(payRef));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }


    }
}
