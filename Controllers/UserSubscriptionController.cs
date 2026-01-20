using Microsoft.AspNetCore.Mvc;
using SubscriptionManagementSystem.Application_Contracts.Dtos;
using SubscriptionManagementSystem.Application_Contracts.IServices;
using SubscriptionManagementSystem.Domain;

namespace SubscriptionManagementSystem.Controllers
{
    [ApiController]
    [Route("api/Subscription-Management/v1/user-subscriptions")]
    public class UserSubscriptionController : ControllerBase
    {
        private readonly IUserSubscriptionAppService _userSubscriptionAppService;

        public UserSubscriptionController(IUserSubscriptionAppService userSubscriptionAppService)
        {
            _userSubscriptionAppService = userSubscriptionAppService;
        }
        [HttpPost]
        public async Task<IActionResult> AssignSubscriptionToUser([FromBody] CreateUserSubscriptionDto input)
        {
            try
            {
                var usid = await _userSubscriptionAppService.CreateUserSubscriptionAsync(input);
                return Ok(new { id = usid });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{userId}/details")]
        public async Task<IActionResult> GetUserSubscriptionDetails(long userId, bool? isActive, int? pageNumber, int? pageSize, string? orderBy)
        {
            try
            {
                var result = await _userSubscriptionAppService.GetUserSubscriptionDetailsAsync(userId, isActive, pageNumber, pageSize, orderBy);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }
        }
    }
}
