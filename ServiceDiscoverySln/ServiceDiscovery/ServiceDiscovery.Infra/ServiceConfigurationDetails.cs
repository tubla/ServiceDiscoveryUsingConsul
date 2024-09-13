namespace ServiceDiscovery.Infra
{
    public class ServiceConfigurationDetails
    {
        public Uri ConsulUrl { get; set; } = default!;
        public Uri ApiUrl { get; set; } = default!;
        public string ApiServiceName { get; set; } = default!;
        public string ApiServiceId { get; set; } = default!;

    }
}
