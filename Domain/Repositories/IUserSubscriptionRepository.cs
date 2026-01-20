namespace SubscriptionManagementSystem.Domain.Repositories
{
    public interface IUserSubscriptionRepository
    {
        Task<long> AddAsync(UserSubscription userSubscription);
        Task<UserSubscription> GetActiveUserSubscriptionbyIdsAsync(long userId, long subscriptionId); // For same type check
        Task<List<UserSubscription>> GetByUserIdAsync(long userId, bool? isActive, int? pageNumber, int? pageSize, string? orderBy);
        Task<UserSubscription> GetByIdsAsync(long Id); //For Payment check
        Task UpdateAsync(UserSubscription userSubscription); // For Payment update 
        Task<int> GetTotalCountByUserIdAsync(long userId, bool? isActive);

    }
}
