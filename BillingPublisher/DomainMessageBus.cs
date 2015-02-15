using System;
using DomainBasics;
using MassTransit;

namespace BillingPublisher
{
    public class DomainMessageBus
    {
        private IServiceBus _bus;

        public void Start()
        {
            Console.WriteLine("Initializing publisher...");

            _bus = ServiceBusFactory.New(cfg =>
            {
                cfg.UseRabbitMq();
                cfg.ReceiveFrom("rabbitmq://localhost/test_queue");
            });

            Console.WriteLine("Publisher initialized");
        }


        public void Stop()
        {
            if (_bus != null)
                _bus.Dispose();
        }

        public void Publish(IDomainMessage message)
        {
            _bus.Publish(message);
        }

        public void Subscribe<T>(Action<T> handleAction) where T : class, IDomainMessage
        {
            _bus.SubscribeHandler(handleAction);
        }
    }
}
