namespace Examples.NSwag.Client.Consumer.Controllers
{
	using Examples.NSwag.Client.Consumer.GeneratedClient;
	using Examples.NSwag.Client.Producer.Contracts.DTOs;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	[ApiController]
	[Route("[controller]/[action]")]
	public class ConsumerController : ControllerBase
	{
		private readonly ILogger<ConsumerController> _logger;
		private readonly IWeatherForecastClient _weatherForecastClient;

		public ConsumerController(ILogger<ConsumerController> logger, IWeatherForecastClient weatherForecastClient)
		{
			_logger = logger;
			_weatherForecastClient = weatherForecastClient;
		}

		[HttpGet]
		public async Task<IEnumerable<WeatherForecast>> GetAll()
		{
			return await _weatherForecastClient.GetAsync();
		}
	}
}
