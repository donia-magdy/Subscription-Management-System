using SubscriptionManagementSystem.Application_Contracts.Dtos;

namespace SubscriptionManagementSystem.Application_Contracts.IServices
{
    public interface ISubscriptionAppService
    {
        Task UpdateSubscriptionAsync(long subscriptionId,UpdateSubscriptionDto input);
    }
}
