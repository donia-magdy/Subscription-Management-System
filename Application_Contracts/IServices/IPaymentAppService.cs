using SubscriptionManagementSystem.Application_Contracts.Dtos;

namespace SubscriptionManagementSystem.Application_Contracts.IServices
{
    public interface IPaymentAppService
    {
        Task<long> AddPaymentAsync(CreatePaymentDto input);

    }
}
