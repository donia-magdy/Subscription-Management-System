using Microsoft.AspNetCore.Mvc;
using SubscriptionManagementSystem.Application_Contracts.Dtos;
using SubscriptionManagementSystem.Application_Contracts.IServices;

namespace SubscriptionManagementSystem.Controllers
{
    [ApiController]
    [Route("api/Subscription-Management/v1/payments")]
    public class PaymentController: ControllerBase
    {
        private readonly IPaymentAppService _paymentAppService;
        public PaymentController(IPaymentAppService paymentAppService)
        {
            _paymentAppService = paymentAppService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromQuery]CreatePaymentDto input)
        {
            try
            {
                var paymentId = await _paymentAppService.AddPaymentAsync(input);
                return Ok(new { Id = paymentId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
