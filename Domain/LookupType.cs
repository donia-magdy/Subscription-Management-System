using System.ComponentModel.DataAnnotations;

namespace SubscriptionManagementSystem.Domain
{
    public class LookupType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<LookupValue> LookupValues { get; set; }

    }
}
