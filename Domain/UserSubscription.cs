using System.ComponentModel.DataAnnotations;

namespace SubscriptionManagementSystem.Domain
{
    public class UserSubscription
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; }
        public Subscription Subscription { get; set; }
        public Payment? Payment { get; set; }

    }

}
