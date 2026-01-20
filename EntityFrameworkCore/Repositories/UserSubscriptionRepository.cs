using Microsoft.EntityFrameworkCore;
using SubscriptionManagementSystem.Domain;
using SubscriptionManagementSystem.Domain.Repositories;

namespace SubscriptionManagementSystem.EntityFrameworkCore.Repositories
{
    public class UserSubscriptionRepository : IUserSubscriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public UserSubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<long> AddAsync(UserSubscription userSubscription)
        {
            _context.UserSubscriptions.Add(userSubscription);
            await _context.SaveChangesAsync();
            return userSubscription.Id;
        }

        public async Task<UserSubscription> GetActiveUserSubscriptionbyIdsAsync(long userId, long subscriptionId)
        {
            return await _context.UserSubscriptions
                .FirstOrDefaultAsync(us => us.UserId == userId && us.SubscriptionId == subscriptionId && us.IsActive==true);
        }

        public async Task<UserSubscription> GetByIdsAsync(long id)
        {
            // Check using user subscription id
            return await _context.UserSubscriptions
                .Include(us => us.Subscription)
                .Include(us => us.Payment)
                .Include(us => us.User)
                .FirstOrDefaultAsync(us => us.Id == id);

        }

        public async Task<List<UserSubscription>> GetByUserIdAsync(long userId, bool? isActive, int? pageNumber, int? pageSize, string? orderBy)
        {
            // Retrieve user subscriptions based on userId with optional filtering, ordering, and pagination
            var result = _context.UserSubscriptions
                .Include(us => us.Subscription)
                .Include(us => us.Payment)
                .Include(us => us.User)
                .Where(us => us.UserId == userId);
            // if isActive filter is provided, add it to the query
            if (isActive.HasValue)
            {
                result = result.Where(us => us.IsActive == isActive.Value);
            }
            // Apply ordering based on the orderBy parameter
            if (!string.IsNullOrEmpty(orderBy))
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "price":
                        result = result.OrderBy(us => us.Subscription.Price);
                        break;
                    case "startdate":
                        result = result.OrderBy(us => us.StartDate);
                        break;
                    case "enddate":
                        result = result.OrderBy(us => us.EndDate);
                        break;
                    case "name":
                        result = result.OrderBy(us => us.Subscription.Name);
                        break;
                    default:
                        result = result.OrderBy(us => us.Id);
                        break;
                }
            }
            // Apply pagination if pageNumber and pageSize are provided
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                result = result.Skip((pageNumber.Value - 1) * pageSize.Value)
                             .Take(pageSize.Value);
            }
            // Execute the query and return the results as a list
            return await result.ToListAsync();
        }

        public async Task<int> GetTotalCountByUserIdAsync(long userId, bool? isActive)
        {
            var query = _context.UserSubscriptions.Where(us => us.UserId == userId);
            if (isActive.HasValue)
                query = query.Where(us => us.IsActive == isActive.Value);

            return await query.CountAsync();
        }

        public async Task UpdateAsync(UserSubscription userSubscription)
        {
            _context.UserSubscriptions.Update(userSubscription);
            await _context.SaveChangesAsync();
        }
    }
}
