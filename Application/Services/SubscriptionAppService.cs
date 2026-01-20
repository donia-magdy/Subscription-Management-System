
using SubscriptionManagementSystem.Application_Contracts.Dtos;
using SubscriptionManagementSystem.Application_Contracts.IServices;
using SubscriptionManagementSystem.Domain.Repositories;

namespace SubscriptionManagementSystem.Application.Services
{
    public class SubscriptionAppService : ISubscriptionAppService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionAppService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }
        public async Task UpdateSubscriptionAsync(long subscriptionId, UpdateSubscriptionDto input)
        {
            // Check if subscription exists
            var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId);
            if (subscription == null)
            {
                throw new Exception("Subscription not found.");
            }
            // Update price and isActive fields if provided
            if (input.Price.HasValue)
            {
                subscription.Price = input.Price.Value;
            }
            if (input.IsActive.HasValue)
            {
                subscription.IsActive = input.IsActive.Value;
            }
            await _subscriptionRepository.UpdateSubscription(subscription);

        }
    }
}
