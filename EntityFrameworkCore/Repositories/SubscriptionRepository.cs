using Microsoft.EntityFrameworkCore;
using SubscriptionManagementSystem.Domain;
using SubscriptionManagementSystem.Domain.Repositories;

namespace SubscriptionManagementSystem.EntityFrameworkCore.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Subscription?> GetByIdAsync(long id)
        {
            return await _context.Subscriptions.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateSubscription(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
            await _context.SaveChangesAsync();
        }
    }
}
