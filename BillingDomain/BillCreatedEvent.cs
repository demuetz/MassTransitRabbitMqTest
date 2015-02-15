using DomainBasics;

namespace BillingDomain
{
    public class BillCreatedEvent : IDomainEvent
    {
        public int AccountId { get; set; }
        public int BillId { get; set; }
    }
}
