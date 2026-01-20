using SubscriptionManagementSystem.Domain_Shared;
using System.ComponentModel.DataAnnotations;

namespace SubscriptionManagementSystem.Domain
{
    public class Subscription
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public Cycle Cycle { get; set; }
        
        public bool IsActive { get; set; }
        public List<UserSubscription> UserSubscriptions { get; set; }
    }
}
