namespace Orders.API.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public OrderStatusDto Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
