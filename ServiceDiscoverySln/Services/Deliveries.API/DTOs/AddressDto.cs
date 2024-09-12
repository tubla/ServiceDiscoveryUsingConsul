namespace Deliveries.API.DTOs
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string StreetAddress { get; set; } = default!;
        public string City { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string Country { get; set; } = default!;
    }
}
