using SubscriptionManagementSystem.Domain;

namespace SubscriptionManagementSystem.Application_Contracts.Dtos
{
    public class UserSubscriptionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public EnumDto Cycle { get; set; }
        public EnumDto? PaymentMethod { get; set; }
        public DateTime? PaidAt { get; set; }
    }
}
