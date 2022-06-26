using Examples.RabbitMQ.Contracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Examples.RabbitMQ.Consumer.Consumers
{
	public class SomeEventReceivedHandler : IConsumer<SomeEventReceived>
    {
        private readonly ILogger<SomeEventReceivedHandler> _logger;

        public SomeEventReceivedHandler(ILogger<SomeEventReceivedHandler> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<SomeEventReceived> context)
        {
            _logger.LogInformation($"Received message \"{context.Message.Message}\" with id \"{context.Message.CorrelationId}\"");
            await Task.CompletedTask;
        }
    }
}