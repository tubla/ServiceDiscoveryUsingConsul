using Consul;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ServiceDiscovery.Infra
{
    public class ConsulClientHostedService : IHostedService
    {
        private readonly IConsulClient _client;
        private readonly ILogger _logger;
        private readonly ServiceConfigurationDetails _config;
        private string _registrationId = string.Empty;

        public ConsulClientHostedService(IConsulClient consulClient,
                                         ServiceConfigurationDetails serviceConfig)
        {
            _client = consulClient;
            _config = serviceConfig;
            using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
                                                .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace));

            _logger = loggerFactory.CreateLogger<ConsulClientHostedService>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _registrationId = $"{_config.ApiServiceName}-{_config.ApiServiceId}";
            var registration = new AgentServiceRegistration
            {
                ID = _registrationId,
                Name = _config.ApiServiceName,
                Address = _config.ApiUrl.Host,
                Port = _config.ApiUrl.Port
            };


            try
            {
                await _client.Agent.ServiceDeregister(registration.ID, cancellationToken);
                await _client.Agent.ServiceRegister(registration, cancellationToken);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error while trying to deregister in StartAsync() : {ex.Message}");
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _client.Agent.ServiceDeregister(_registrationId, cancellationToken);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error while trying to deregister in StopAsync(): {ex.Message}");
            }

        }
    }
}
