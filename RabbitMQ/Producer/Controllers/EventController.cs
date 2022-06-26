namespace Examples.RabbitMQ.Producer.Controllers
{
	using Examples.RabbitMQ.Contracts.Events;
	using MassTransit;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using System;
	using System.Threading.Tasks;

	[ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
	{
		private readonly IPublishEndpoint _publishEndpoint;
		private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger, IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			return Ok("Healthy");
		}

		[HttpPost]
        public async Task<ActionResult> Post(string message)
        {
            _logger.LogInformation($"User submitted a message \"{message}\"");
            await _publishEndpoint.Publish<SomeEventReceived>(new
            {
                CorrelationId = Guid.NewGuid(),
                Message = message
            });
            return Ok();
        }
    }
}