namespace Deliveries.API.Models
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public string Comment { get; set; } = default!;
        public string Contact { get; set; } = default!;
        public Address FromAddress { get; set; } = null!;
        public Address ToAddress { get; set; } = null!;
        public Guid OrderId { get; set; }
    }
}