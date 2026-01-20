namespace SubscriptionManagementSystem.Application_Contracts.Dtos
{
    public class UserSubscriptionsDetailsDto
    {
        public UserDto User { get; set; }
        public List<UserSubscriptionDto> Subscriptions { get; set; }
        public int TotalCount { get; set; }
    }
}
