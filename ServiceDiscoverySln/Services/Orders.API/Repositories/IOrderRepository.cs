using Orders.API.Models;

namespace Orders.API.Repositories
{
    public interface IOrderRepository
    {
        Order GetOrder(Guid orderId);
        IEnumerable<Order> GetOrders(Guid customerId);
    }
}