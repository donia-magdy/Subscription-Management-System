using SubscriptionManagementSystem.Application_Contracts.Dtos;

namespace SubscriptionManagementSystem.Application_Contracts.IServices
{
    public interface IUserAppService
    {
        Task<long> CreateUserAsync(CreateUserDto input);
        Task DeleteUserAsync(long id);
        Task<List<UserDto>> GetAllUsersAsync();
    }
}
