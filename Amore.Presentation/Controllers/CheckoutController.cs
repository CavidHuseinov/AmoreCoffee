using Amore.Business.Helpers.DTOs.Checkout;
using Amore.Business.Helpers.Exceptions;
using Amore.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Amore.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost("process-payment")]
        public async Task<IActionResult> ProcessPayment([FromForm] CreateCheckoutDto dto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //try
            //{
            var checkout = await _checkoutService.ProcessPaymentAsync(dto);
            return Ok(checkout);
            //}
            //catch (PaymentFailedException ex)
            //{
            //    return BadRequest(new { message = "Ödəmə uğursuz oldu", error = ex.Message });
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }
    }
}
