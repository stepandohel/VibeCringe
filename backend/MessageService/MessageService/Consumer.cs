using Confluent.Kafka;

namespace MessageService
{

    public class Consumer : BackgroundService
    {
        private readonly ILogger<Consumer> _logger;

        public Consumer(ILogger<Consumer> logger)
        {
            _logger = logger;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                var configProducer = new ProducerConfig { BootstrapServers = "kafka:9092" };
                using var producer = new ProducerBuilder<Null, string>(configProducer).Build();
                producer.Produce("test-topic", new Message<Null, string> { Value = "Consumer start work !" });

                var config = new ConsumerConfig
                {
                    GroupId = "test-consumer-group",
                    BootstrapServers = "kafka:9092",
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                    AllowAutoCreateTopics = true
                };
                using var consumer = new ConsumerBuilder<Null, string>(config).Build();
                consumer.Subscribe("test-topic");
                while (true)
                {
                    var response = consumer.Consume(TimeSpan.FromSeconds(1));
                    if (response is not null)
                        if (response.Message is not null)
                        {
                            _logger.LogInformation(response.Message.Value);
                        }
                }
            });
        }
    }
}
