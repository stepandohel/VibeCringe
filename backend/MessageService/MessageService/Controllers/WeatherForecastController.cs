using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string message)
        {
            var config = new ProducerConfig { BootstrapServers = "kafka:9092" };
            using var producer = new ProducerBuilder<Null, string>(config).Build();
            await producer.ProduceAsync("test-topic", new Message<Null, string> { Value = message });
            return Ok();
        }
    }
}