using SubscriptionManagementSystem.Domain_Shared;

namespace SubscriptionManagementSystem.Application_Contracts.Dtos
{
    public class CreatePaymentDto
    {
        public long UserSubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public long PaymentMethod { get; set; }
    }
}
