using System.ComponentModel.DataAnnotations;

namespace SubscriptionManagementSystem.Domain
{
    public class LookupValue
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long LookupTypeId { get; set; }
        public LookupType LookupType { get; set; }
    }
}
