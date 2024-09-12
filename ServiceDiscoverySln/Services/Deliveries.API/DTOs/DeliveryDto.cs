namespace Deliveries.API.DTOs
{
    public class DeliveryDto
    {
        public Guid Id { get; set; }
        public string Comment { get; set; } = default!;
        public string Contact { get; set; } = default!;
        public AddressDto FromAddress { get; set; } = null!;
        public AddressDto ToAddress { get; set; } = null!;
    }
}
