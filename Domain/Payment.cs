using SubscriptionManagementSystem.Domain_Shared;
using System.ComponentModel.DataAnnotations;

namespace SubscriptionManagementSystem.Domain
{
    public class Payment
    {
        public long Id { get; set; }
        public long UserSubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaidAt { get; set; }
        public PaymentMethod? PaymentMethod { get; set; } 
        public UserSubscription UserSubscription { get; set; }
    }
}
