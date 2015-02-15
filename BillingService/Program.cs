using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BillingDomain;
using BillingPublisher;

namespace BillingService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing");

            var bus = new DomainMessageBus();

            bus.Start();

            bus.Subscribe<CreateBillCommand>(CreateBill);




            Console.WriteLine("Press ENTER to exit");

            Console.ReadLine();
        }

        private static void CreateBill(CreateBillCommand cmd)
        {
            Console.WriteLine("Creating bill for account " + cmd.AccountId);
        }
    }
}
