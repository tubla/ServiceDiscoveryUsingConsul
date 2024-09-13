using Consul;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceDiscovery.Infra
{
    /// <summary>
    /// RegisterConsulServices() extension will be used by the microservices to register their addresses to the consul service discovery
    /// </summary>
    public static class ConsulClientDependencyInjectionExtensions
    {
        public static void RegisterConsulServices(this IServiceCollection services, ServiceConfigurationDetails serviceConfig)
        {
            if (serviceConfig == null)
            {
                throw new ArgumentNullException(nameof(serviceConfig));
            }

            var consulClient = new ConsulClient(config =>
            {
                config.Address = serviceConfig.ConsulUrl;
            });

            services.AddSingleton(serviceConfig);
            services.AddSingleton<IHostedService, ConsulClientHostedService>();
            services.AddSingleton<IConsulClient, ConsulClient>(provider => consulClient);


        }
    }
}
