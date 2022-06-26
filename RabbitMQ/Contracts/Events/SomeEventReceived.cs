using System;

namespace Examples.RabbitMQ.Contracts.Events
{
	public interface SomeEventReceived
    {
        public Guid CorrelationId { get; set; }
        public string Message { get; set; }
    }
}