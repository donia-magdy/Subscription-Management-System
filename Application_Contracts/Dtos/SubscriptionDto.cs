using SubscriptionManagementSystem.Domain_Shared;

namespace SubscriptionManagementSystem.Application_Contracts.Dtos
{
    public class SubscriptionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Cycle Cycle { get; set; }

        public bool IsActive { get; set; }
    }
}
