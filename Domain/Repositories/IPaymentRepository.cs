namespace SubscriptionManagementSystem.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task<long> AddPaymentAsync(Payment payment);
    }
}
