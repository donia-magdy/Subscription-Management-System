using SubscriptionManagementSystem.Application_Contracts.Dtos;

namespace SubscriptionManagementSystem.Application_Contracts.IServices
{
    public interface IUserSubscriptionAppService
    {
        Task<long> CreateUserSubscriptionAsync(CreateUserSubscriptionDto input);
        Task<UserSubscriptionsDetailsDto> GetUserSubscriptionDetailsAsync(long userId, bool? isActive, int? pageNumber, int? pageSize, string? orderBy);

    }
}
