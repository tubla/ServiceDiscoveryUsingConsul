namespace Gateway.API.Middleware
{
    public class DownstreamUrlHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            using var client = new HttpClient(handler);
            // Proceed with your logic
            return await base.SendAsync(request, token);
        }
    }
}
