namespace Examples.RabbitMQ.Consumer
{
	using MassTransit;
	using Microsoft.Extensions.Hosting;
	using Microsoft.Extensions.Logging;
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class MassTransitHostedService : IHostedService
    {
        private IHostApplicationLifetime _host;
        private IBusControl _busControl;
        private ILogger<MassTransitHostedService> _logger;

        public MassTransitHostedService(IHostApplicationLifetime host, ILogger<MassTransitHostedService> logger, IBusControl busControl)
        {
            _host = host;
            _logger = logger;
            _busControl = busControl;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("start async");
            try
            {
                var handle = await _busControl.StartAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("stop async");
            await _busControl.StopAsync();
        }
    }
}