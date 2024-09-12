namespace Deliveries.API.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string StreetAddress { get; set; } = default!;
        public string City { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string Country { get; set; } = default!;

    }
}