using SubscriptionManagementSystem.Domain;
using SubscriptionManagementSystem.Domain.Repositories;

namespace SubscriptionManagementSystem.EntityFrameworkCore.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<long> AddPaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment.Id;
        }
    }
}
