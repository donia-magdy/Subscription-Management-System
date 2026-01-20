using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubscriptionManagementSystem.Application_Contracts.Dtos;
using SubscriptionManagementSystem.Application_Contracts.IServices;
using SubscriptionManagementSystem.Domain;
using SubscriptionManagementSystem.EntityFrameworkCore;

namespace SubscriptionManagementSystem.Controllers
{
    [ApiController]
    [Route("api/Subscription-Management/v1/users")]
    public class UserController: ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            try
            {
                var userId = await _userAppService.CreateUserAsync(dto);
                return Ok(new { id = userId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            await _userAppService.DeleteUserAsync(id);

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userAppService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
