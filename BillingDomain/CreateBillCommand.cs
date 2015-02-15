using DomainBasics;

namespace BillingDomain
{
    public class CreateBillCommand : IDomainCommand
    {
        public int AccountId { get; set; }
    }
}
