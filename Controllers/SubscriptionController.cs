using Microsoft.AspNetCore.Mvc;
using SubscriptionManagementSystem.Application_Contracts.Dtos;
using SubscriptionManagementSystem.Application_Contracts.IServices;

namespace SubscriptionManagementSystem.Controllers
{
    [ApiController]
    [Route("api/Subscription-Management/v1/subscriptions")]
    public class SubscriptionController: ControllerBase
    {
        private readonly ISubscriptionAppService _subscriptionAppService;

        public SubscriptionController(ISubscriptionAppService subscriptionAppService)
        {
            _subscriptionAppService = subscriptionAppService;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscription(long id, [FromBody]UpdateSubscriptionDto input)

        {
            try
            {
                await _subscriptionAppService.UpdateSubscriptionAsync(id, input);
                            return Ok();
            }catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
        }
    }
}
