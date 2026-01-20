namespace SubscriptionManagementSystem.Application_Contracts.Dtos
{
    public class UpdateSubscriptionDto
    {
        public decimal? Price { get; set; }
        public bool? IsActive { get; set; }
    }
}
