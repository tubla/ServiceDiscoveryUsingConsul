using Orders.API.Models;

namespace Orders.API.Repositories
{

    public class OrderRepository : IOrderRepository
    {
        private static readonly Random _random = new Random();

        public IEnumerable<Order> GetOrders(Guid customerId)
        {
            var numberOfOrders = _random.Next(0, 10);
            var orders = new List<Order>(numberOfOrders);

            for (var i = 0; i < numberOfOrders; i++)
            {
                var order = CreateOrder(customerId, Guid.NewGuid());
                orders.Add(order);
            }
            return orders;
        }

        public Order GetOrder(Guid orderId)
        {
            return CreateOrder(Guid.NewGuid(), orderId);
        }

        private static Order CreateOrder(Guid customerId, Guid orderId)
        {
            return new Order
            {
                Id = orderId,
                Status = OrderStatus.Created,
                CustomerId = customerId,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };
        }
    }
}
