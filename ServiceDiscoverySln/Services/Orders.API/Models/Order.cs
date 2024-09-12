namespace Orders.API.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public OrderStatus Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public Guid CustomerId { get; set; }
    }
}
