using Microsoft.Extensions.Configuration;

namespace ServiceDiscovery.Infra
{
    public static class ServiceConfigurationDetailsExtensions
    {
        public static ServiceConfigurationDetails GetServiceDetailsConfiguration(this IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            // Read configuration details from the consumer api microservice
            var serviceConfigModel = new ServiceConfigurationDetails
            {
                ConsulUrl = configuration.GetValue<Uri>("ServiceConfigurationDetails:ConsulUrl")!,
                ApiUrl = configuration.GetValue<Uri>("ServiceConfigurationDetails:ApiUrl")!,
                ApiServiceName = configuration.GetValue<string>("ServiceConfigurationDetails:ApiServiceName")!,
                ApiServiceId = configuration.GetValue<string>("ServiceConfigurationDetails:ApiServiceId")!,
            };
            return serviceConfigModel;
        }

    }
}
