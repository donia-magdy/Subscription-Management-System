using System.ComponentModel.DataAnnotations;

namespace SubscriptionManagementSystem.Domain
{
    public class User
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<UserSubscription> UserSubscriptions { get; set; }

    }
}
