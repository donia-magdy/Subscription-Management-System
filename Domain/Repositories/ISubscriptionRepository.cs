namespace SubscriptionManagementSystem.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<Subscription?> GetByIdAsync(long id);
        Task UpdateSubscription(Subscription subscription);
    }
}
